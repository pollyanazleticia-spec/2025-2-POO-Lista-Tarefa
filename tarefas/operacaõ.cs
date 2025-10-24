public void Alterar(Tarefa tarefa)
{
    using (var conexao = new MySqlConnection(connectionString))
    {
        conexao.Open();

        string sql = @"UPDATE tarefa
                       SET nome = @nome,
                           descricao = @descricao,
                           dataCriacao = @dataCriacao,
                           status = @status,
                           dataExecucao = @dataExecucao
                       WHERE id = @id;";

        using (var cmd = new MySqlCommand(sql, conexao))
        {
            cmd.Parameters.AddWithValue("@nome", tarefa.Nome);
            cmd.Parameters.AddWithValue("@descricao", tarefa.Descricao);
            cmd.Parameters.AddWithValue("@dataCriacao", tarefa.DataCriacao);
            cmd.Parameters.AddWithValue("@status", tarefa.Status);

            if (tarefa.DataExecucao.HasValue)
                cmd.Parameters.AddWithValue("@dataExecucao", tarefa.DataExecucao.Value);
            else
                cmd.Parameters.AddWithValue("@dataExecucao", DBNull.Value);

            cmd.Parameters.AddWithValue("@id", tarefa.Id);

            cmd.ExecuteNonQuery();
        }
    }
}

public void Excluir(int id)
{
    using (var conexao = new MySqlConnection(connectionString))
    {
        conexao.Open();

        string sql = "DELETE FROM tarefa WHERE id = @id;";

        using (var cmd = new MySqlCommand(sql, conexao))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}

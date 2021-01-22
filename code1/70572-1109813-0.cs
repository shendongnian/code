    string sql = ...;
    using (var cn = new SqlConnection(ConnectionString()))
    {
        cn.Open();
        using (cmd = new SqlCommand(sql, cn))
        {
            cmd.CommandType = CommandType.Text;
            return (int) cmd.ExecuteScalar();
        }
    }    

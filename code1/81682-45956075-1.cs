    using (NpgsqlConnection connection = new NpgsqlConnection(< connectionString >))
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        connection.Open();
        NpgsqlCommand cmd = new NpgsqlCommand(< name of your SP >, connection);
        cmd.CommandType = CommandType.StoredProcedure;
        var param = cmd.CreateParameter();
        param.ParameterName = < exact parameterName you used in your SP>;
        param.DbType = System.Data.DbType.AnsiString;
        param.Value = < parameter value >;
        cmd.Parameters.Add(param);
        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
        adapter.Fill(ds);
        dt = ds.Tables[0];
    }
    
    

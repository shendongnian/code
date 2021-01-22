    using (DbCommand command = connection.CreateCommand())
    {
        command.CommandText = "insert myTable (column1) values @myParameter";
        command.CommandType = CommandType.Text;
    
        DbParameter parameter = command.CreateParameter();
        parameter.ParameterName = "myParameter";
        parameter.DbType = DbType.AnsiString;
        parameter.Size = 100;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = "foo";
    
        command.ExecuteNonQuery();
    }

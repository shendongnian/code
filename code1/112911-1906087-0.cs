    using (DbCommand command = connection.CreateCommand())
    {
        command.CommandText = "myStoredProc";
        command.CommandType = CommandType.StoredProcedure;
    
        DbParameter parameter = command.CreateParameter();
        parameter.ParameterName = "myParameter";
        parameter.DbType = DbType.AnsiString;
        parameter.Size = 100;
        parameter.Direction = ParameterDirection.Input;
        parameter.Value = "foo";
    
        command.ExecuteNonQuery();
    }

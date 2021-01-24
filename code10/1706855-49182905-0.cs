    using (var command = context.Database.GetDbConnection().CreateCommand())
    	{
    		command.CommandText = "StoredProcedureName";
    		command.CommandType = CommandType.StoredProcedure;
    
    		context.Database.OpenConnection();
    
    		var dataReader = command.ExecuteReader();
    
    		if (dataReader.Read())
    		{
    			string _test = dataReader.GetString(dataReader.GetOrdinal("ColumnName"));
    		}
    	}

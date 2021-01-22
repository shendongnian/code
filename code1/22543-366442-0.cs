    using (OracleConnection conn = new OracleConnection("connection string here"))
    {
    	conn.Open();
    
    	OracleCommand command = conn.CreateCommand();
    	command.CommandType = CommandType.StoredProcedure;
    
    	command.CommandText = "DATABASE_NAME_HERE.SPROC_NAME_HERE";
    	// Call command.Parameters.Add to add your parameters.
    	
    	using (OracleReader reader = command.ExecuteReader())
    	{
    		while(reader.Read())
    		{
    			// Process each row
    		}
    	}
    		
    }

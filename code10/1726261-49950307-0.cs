    public ValueTuple<bool, List<KeyRow>> RunSelectAllKeyRowCommand(IDbCommand command, List<IDataParameter> parameterCollection) =>
    	RunSelectAllCommandImpl<KeyRow>(command, 
                                        parameterCollection,
                                        reader => new KeyRow(reader["keycode"].ToString(), reader["apikey"].ToString(), reader["ipaddress"].ToString(), DateTime.Parse(reader["date"].ToString()), reader["hwid"].ToString() ?? ""));
    
    private ValueTuple<bool, List<T>> RunSelectAllCommandImpl<T>(IDbCommand command, List<IDataParameter> parameterCollection, Func<IDataReader, T> mapper) where T : class
    {
    	using (IDbConnection conn = GetDataConnection())
    	using (var cmd = conn.CreateCommand())
    	{
    		conn.Open();
    		cmd.CommandText = command.CommandText;
    		
    		foreach(var parameter in parameterCollection) // if parameters for query are specified, add them here.
    			cmd.Parameters.Add(parameter);
    		
    		using (var reader = cmd.ExecuteReader())
    		{
    			List<T> data = new List<T>();
    			
    			while (reader.Read())
    				data.Add(mapper(reader));
    
    			return (true, data);
    		}
    	}
    	
    	return (false, null);
    }

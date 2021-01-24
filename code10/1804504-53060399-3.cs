    public IEnumerable<dynamic> GetDynamicResult(string commandText, params SqlParameter[] parameters)
    {
    	// Get the connection from DbContext
    	var connection = DbContext.Database.GetDbConnection();
    
    	// Open the connection if isn't open
    	if (connection.State != System.Data.ConnectionState.Open)
    		connection.Open();
    
    	using (var command = connection.CreateCommand())
    	{
    		command.CommandText = commandText;
    		command.Connection = connection;
    
    		if (parameters?.Length > 0)
    		{
    			foreach (var parameter in parameters)
    			{
    				command.Parameters.Add(parameter);
    			}
    		}
    
    		using (var dataReader = command.ExecuteReader())
    		{
    			// List for column names
    			var names = new List<string>();
    
    			if (dataReader.HasRows)
    			{
    				// Add column names to list
    				for (var i = 0; i < dataReader.VisibleFieldCount; i++)
    				{
    					names.Add(dataReader.GetName(i));
    				}
    
    				while (dataReader.Read())
    				{
    					// Create the dynamic result for each row
    					var result = new ExpandoObject() as IDictionary<string, object>;
    
    					foreach (var name in names)
    					{
    						// Add key-value pair
    						// key = column name
    						// value = column value
    						result.Add(name, dataReader[name]);
    					}
    
    					yield return result;
    				}
    			}
    		}
    	}
    }

    using (var connection = new MySqlConnection("Server = localhost; Database = app_erp_suneka; Uid = root; Pwd = ;"))
    {
    	connection.Open();
    
    	// get the names of all tables in the chosen database
    	var tableNames = new List<string>();
    	using (var command = new MySqlCommand(@"SELECT table_name FROM information_schema.tables where table_schema = @database", connection))
    	{
    		command.Parameters.AddWithValue("@database", "app_erp_suneka");
    		using (var reader = command.ExecuteReader())
    		{
    			while (reader.Read())
    				tableNames.Add(reader.GetString(0));
    		}
    	}
    
    	// open a JSON file for output; use the streaming JsonTextWriter interface to avoid high memory usage
    	using (var streamWriter = new StreamWriter(@"C:\Temp\app_erp_suneka.json"))
    	using (var jsonWriter = new JsonTextWriter(streamWriter) { Formatting = Newtonsoft.Json.Formatting.Indented, Indentation = 2, IndentChar = ' ' })
    	{
    		// one array to hold all tables
    		jsonWriter.WriteStartArray();
    		
    		foreach (var tableName in tableNames)
    		{
    			// an object for each table
    			jsonWriter.WriteStartObject();
    			jsonWriter.WritePropertyName("tableName");
    			jsonWriter.WriteValue(tableName);
    			jsonWriter.WritePropertyName("rows");
    			
    			// an array for all the rows in the table
    			jsonWriter.WriteStartArray();
    			
    			// select all the data from each table
    			using (var command = new MySqlCommand($@"SELECT * FROM `{tableName}`", connection))
    			using (var reader = command.ExecuteReader())
    			{
    				while (reader.Read())
    				{
    					// write each row as a JSON object
    					jsonWriter.WriteStartObject();
    					for (int i = 0; i < reader.FieldCount; i++)
    					{
    						jsonWriter.WritePropertyName(reader.GetName(i));
    						jsonWriter.WriteValue(reader.GetValue(i));
    					}
    					jsonWriter.WriteEndObject();
    				}
    			}
    			
    			jsonWriter.WriteEndArray();
    			jsonWriter.WriteEndObject();
    		}
    		
    		jsonWriter.WriteEndArray();
    	}
    }

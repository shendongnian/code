    var result = new StringBuilder();
    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString)) {
    	con.Open();
    	using (var cmd = con.CreateCommand()) {
    		cmd.CommandText = @"
    DECLARE @name VARCHAR(255)
    DECLARE iterator CURSOR FOR SELECT name FROM sys.tables WHERE type='U'
    OPEN iterator
    FETCH NEXT FROM iterator INTO @name
    WHILE @@FETCH_STATUS = 0 BEGIN
        SELECT @name name
        EXEC ('SELECT * FROM ' + @name)
        FETCH NEXT FROM iterator INTO @name
    END
    CLOSE iterator
    DEALLOCATE iterator
    ";
    		using (var reader = cmd.ExecuteReader()) {
    			do {
    				// get table name
    				reader.Read();
    				string tableName = reader[0].ToString();
    
    				// get contents
    				reader.NextResult();
    				result
    					.Append("SET IDENTITY_INSERT ")
    					.Append(tableName)
    					.Append(" ON\r\n");
    				while (reader.Read()) {
    					result
    						.Append("INSERT ")
    						.Append(tableName)
    						.Append(" (");
    					for (var x = 0; x < reader.FieldCount; x++)
    						result
    							.Append(x == 0 ? string.Empty : ",")
    							.Append("[" + reader.GetName(x) + "]");
    					result
    						.Append(" ) VALUES (");
    					for (var x = 0; x < reader.FieldCount; x++)
    						result
    							.Append(x == 0 ? string.Empty : ",")
    							.Append("'" + reader[x].ToString() + "'");
    					result
    						.Append(")\r\n");
    				}
    				result
    					.Append("SET IDENTITY_INSERT ")
    					.Append(tableName)
    					.Append(" OFF\r\n");
    			} while (reader.NextResult());
    		}
    	}
    }
    
    Response.Write(result);

    using (SqlConnection connection = new SqlConnection(conn_str))
    {
    		connection.Open();
    		using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
    		{
    			bulkCopy.DestinationTableName = string.Format("[{0}].[{1}].[{2}]", targetDatabase, targetSchema, targetTable);
    			var targetColumsAvailable = GetSchema(conn_str, targetTable).ToArray();
    			foreach (var column in dt.Columns)
    			{
    				if (targetColumsAvailable.Select(x => x.ToUpper()).Contains(column.ToString().ToUpper()))
    				{
    					var tc = targetColumsAvailable.Single(x => String.Equals(x, column.ToString(), StringComparison.CurrentCultureIgnoreCase));
    					bulkCopy.ColumnMappings.Add(column.ToString(), tc);
    				}
    			}
    
    			// Write from the source to the destination.
    			bulkCopy.WriteToServer(dt);
    			bulkCopy.Close();
    		}
    }

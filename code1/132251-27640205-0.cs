    public static DataTable GetDataTableSchemaFromTable(string tableName, SqlConnection sqlConn, SqlTransaction transaction)
    {
    	DataTable dtResult = new DataTable();
    
    	using (SqlCommand command = sqlConn.CreateCommand())
    	{
    		command.CommandText = String.Format("SELECT TOP 1 * FROM {0}", tableName);
    		command.CommandType = CommandType.Text;
    		if (transaction != null)
    		{
    			command.Transaction = transaction;
    		}
    
    		SqlDataReader reader = command.ExecuteReader(CommandBehavior.SchemaOnly);
    
    		dtResult.Load(reader);
    
    	}
    
    	return dtResult;
    }

    private void LogSave(DynamicParameters parameters)
    {    
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
    
            using (var transaction = connection.BeginTransaction())
            {
                var logItemCommand = new CommandDefinition(commandText: Constants.InsertLogItem,
                    parameters: parameters, transaction: transaction, commandType: System.Data.CommandType.Text);
    
                try
    			{
    				connection.Execute(logItemCommand);
    				transaction.Commit();
    			}
    			catch (Exception exc)
    			{
    				transaction.Rollback();
    				throw;
    			}
            }
    	}
    }

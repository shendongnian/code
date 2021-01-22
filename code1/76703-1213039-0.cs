    // Create connection
    SqlConnection connection = ObtainSqlConnection()
    
    // Create transaction
    SqlTransaction sqlTransaction = connection.BeginTransaction();
    try
    {    
        foreach (Action action in collectionOfActionsToPerform)
        {
    	    action.Publish(sqlTransaction)
        }
    	sqlTransaction.Commit();
    }
    catch
    {
    	sqlTransaction.Rollback();
    }

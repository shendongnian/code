    dataContext.Connection.Open();
    using (dataContext.Transaction = dataContext.Connection.BeginTransaction())
    {
    	dataContext.SubmitChanges();
    
    	if (allOK)
    	{
    		dataContext.Transaction.Commit();
    	}
    	else
    	{
    		dataContext.Transaction.RollBack();
    	}
    }

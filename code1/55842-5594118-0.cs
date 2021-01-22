    dataContext.Connection.Open();
    using (datacontext.Transaction = dataContext.Connection.BeginTransaction())
    {
    	dataContext.SubmitChanges();
    
    	if (allOK)
    	{
    		datacontext.Transaction.Commit();
    	}
    	else
    	{
    		datacontext.Transaction.RollBack();
    	}
    }

    using (var txn = new TransactionScope(
        TransactionScopeOption.Required, 
        new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadUncommitted
        }
    ))
    {
        
    }

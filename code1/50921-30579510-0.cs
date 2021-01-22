    new TransactionScope(TransactionScopeOption.Required, 
        new TransactionOptions 
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TransactionManager.MaximumTimeout
        }
    )

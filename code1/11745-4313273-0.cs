    TransactionOptions options = new TransactionOptions();
    options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
    options.Timeout = new TimeSpan(0, 15, 0);
    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required,options))
    {
        sp1();
        sp2();
        ...
    
    }

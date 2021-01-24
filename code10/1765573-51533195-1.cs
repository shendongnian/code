    using (var txn = new TransactionScope(
        TransactionScopeOption.Required, 
        new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadUncommitted
        }
    ))
    {
        var count = from c in EmployeeDependent where c.GCPDocumentId = GCPDocumentId
        select new (DependantsTravelling = c.Count())
    }

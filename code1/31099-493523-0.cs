    IQueryable<Transaction> query = db.Transactions;
    
    if (filterByTransactionType)
    {
      query = query.Where(t => t.TransactionType == theTransactionType);
    }
    if (filterByResponseCode)
    {
      query = query.Where(t => t.ResponseCode == theResponseCode);
    }
    if (filterByAmount)
    {
      query = query.Where(t => t.TransactionAmount > theAmount);
    }

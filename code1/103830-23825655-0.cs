    using (var sqlConnection = new ConnectionScope())
    using (var transaction = new TransactionScope())
    {
        sqlConnection.EnlistTransaction(System.Transactions.Transaction.Current);
        // Do something that modifies data
        transaction.Complete();
    }

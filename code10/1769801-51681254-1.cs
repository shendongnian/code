    var txOptions = new System.Transactions.TransactionOptions();
    txOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
    
    using(var transaction = new TransactionScope(TransactionScopeOption.Required, txOptions))
    using (var connection = new MySqlConnection("... connection string ..."))
    {
        connection.Open();
        // ...
        transaction.Complete();
    }

    //declare the transaction options
    var transactionOptions = new System.Transactions.TransactionOptions();
    //set that we want to read uncommited data
    transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
    //create the transaction scope, passing our options in
    using (var transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, transactionOptions))
    {
        //declare our context
        using (var context = new MyEntityConnection())
        {
            //any reads we do here will also read uncomitted data
            //...
            //...
        }
    }

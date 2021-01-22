	// creates the right transaction scope
	public static System.Transactions.TransactionScope CreateTransactionScope() 
        // needs to add ref: System.Transactions
	 { 
		var transactionOptions = new TransactionOptions 
		{ 
			IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
			Timeout = new TimeSpan(0,0,10,0,0) //assume 10 min is the timeout time
		}; 
		var scopeOption=TransactionScopeOption.RequiresNew;
		var scope = new System.Transactions.TransactionScope(scopeOption, 
                   transactionOptions); 
		return scope;
	} 

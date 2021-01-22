    public static TransactionScope CreateTransactionScope()
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                    Timeout = TransactionManager.MaximumTimeout
                };
               
                return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
            }

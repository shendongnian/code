    public static TransactionScope CreateTransactionScope()
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.MaxValue
                };
               
                return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
            }

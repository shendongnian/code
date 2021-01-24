    public TOut PerformDbOperation<TOut>(IDbOperation<TOut> operation, bool withinTransaction)
    {
        IDbConnection db = GetNewDbConnection();
        OpenConnection(db);
        IDbTransaction transaction = null;
    
        if (withinTransaction) {
            transaction = db.BeginTransaction();
        }
    
        try {
            operation.Execute(db);
            if (withinTransaction) {
                transaction.Commit();
            }
            return operation.Result;
        }
        finally {
            if (withinTransaction) {
                transaction.Dispose();
            }
            CloseConnection(db);
        }
    }

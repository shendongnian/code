    public TOut PerformDbOperation<TOut>(Function<IDbConnection,TOut> method, bool withinTransaction)
    {
        IDbConnection db = GetNewDbConnection();
        OpenConnection(db);
        IDbTransaction transaction = null;
    
        if (withinTransaction) {
            transaction = db.BeginTransaction();
        }
    
        try {
            TOut result = method(db);
            if (withinTransaction) {
                transaction.Commit();
            }
            return result;
    
        }
        finally {
            if (withinTransaction) {
                transaction.Dispose();
            }
            CloseConnection(db);
        }
    }

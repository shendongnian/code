    public static List<T> ToListReadUncommited<T>(this IQueryable<T> query)
    {
        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
        {
            List<T> toReturn = query.ToList();
            scope.Complete();
            return toReturn;
        }
    }
    
    public static int CountReadUncommited<T>(this IQueryable<T> query)
    {
        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
        {
            int toReturn = query.Count();
            scope.Complete();
            return toReturn;
        }
    }

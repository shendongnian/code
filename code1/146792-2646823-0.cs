    public static IQueryable<T> SortTable<T>(
        IQueryable<T> q, string sortfield, bool ascending)
    {
        var p = Expression.Parameter(typeof(T), "p");
        var x = Expression.Lambda(Expression.Property(p, sortfield), p);
    
        return q.Provider.CreateQuery<T>(
                   Expression.Call(typeof(Queryable),
                                   ascending ? "OrderBy" : "OrderByDescending",
                                   new Type[] { q.ElementType, x.Body.Type },
                                   q.Expression,
                                   x));
    }

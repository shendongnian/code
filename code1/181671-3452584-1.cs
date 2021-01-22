    IQueryable<T> testAdd<T>(IQueryable<T> query,
        Expression<Func<T, string>> select, string find)
    {
        var parameter = Expression.Parameter(typeof(T), null);
        return query.Where(
            Expression.Lambda<Func<T, bool>>(
                Expression.Call(
                    Expression.Invoke(select, parameter),
                    "StartsWith",
                    null,
                    Expression.Constant(find)),
                parameter));
    }

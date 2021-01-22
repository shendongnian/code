    public static IQueryable<TResult> WithFieldLike<TResult>(
       this IQueryable<TResult> query,
       Expression<Func<TResult, string>> field,
       string value)
    {
        var param = Expression.Parameter(typeof(TResult), "x");
        var expr = Expression.Lambda<Func<TResult, bool>>(
            Expression.Call(Expression.Invoke(field, param),
                "Contains", null, Expression.Constant(value)), param);
        return query.Where(expr);
    }

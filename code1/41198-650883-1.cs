    public static IQueryable<T> WhereAnyOf<T>(
        this IQueryable<T> source,
        params Expression<Func<T, bool>>[] predicates)
    {
        if (source == null) throw new ArgumentNullException("source");
        if (predicates == null) throw new ArgumentNullException("predicates");
        if (predicates.Length == 0) return source.Where(row => false);
        if (predicates.Length == 1) return source.Where(predicates[0]);
        var param = Expression.Parameter(typeof(T), "row");
        Expression body = Expression.Invoke(predicates[0], param);
        for (int i = 1; i < predicates.Length; i++)
        {
            body = Expression.OrElse(body,
                Expression.Invoke(predicates[i], param));
        }
        return source.Where(Expression.Lambda<Func<T, bool>>(body, param));
    }

    public static IQueryable<TSource> WhereContains<TSource, TResult>(this IQueryable<TSource> query, Expression<Func<TSource, TResult>> column, IList<TResult> values)
    {
        MethodInfo iListTResultContains = typeof(ICollection<>).MakeGenericType(typeof(TResult)).GetMethod("Contains", BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(TResult) }, null);
            
        var contains = Expression.Call(Expression.Constant(values), iListTResultContains, column.Body);
        var lambda = Expression.Lambda<Func<TSource, bool>>(contains, column.Parameters);
        return query.Where(lambda);
    }

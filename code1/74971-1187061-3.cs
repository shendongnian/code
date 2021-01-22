    public static IQueryable<T> WhereDateRange<T>(
        this IQueryable<T> source, Expression<Func<T, DateTime>> getter,
        DateTime from, DateTime to)
    {
        Expression body = getter.Body;
        var predicate = Expression.Lambda<Func<T, bool>>(
            Expression.And(
                Expression.GreaterThan(body, Expression.Constant(from)),
                Expression.LessThan(body, Expression.Constant(to))
            ),
            getter.Parameters);
        return source.Where(predicate);
    }

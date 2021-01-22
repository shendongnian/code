    public static IQueryable<T> Where<T>(this IQueryable<T> query,
        string propertyName, object value)
    {
        PropertyInfo prop = typeof(T).GetProperty(propertyName);
        var param = Expression.Parameter(typeof(T), "x");
        var body = Expression.Equal(
            Expression.Property(param, prop),
            Expression.Constant(value, prop.PropertyType)
            );
        var predicate = Expression.Lambda<Func<T, bool>>(body, param);
        return query.Where(predicate);
    }

    private static Func<T, U> GetPropertyFunc<T, U>(string propertyName)
    {
        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.PropertyOrField(parameter, propertyName);
        var lambda = Expression.Lambda<Func<T, U>>(body, parameter);
        return lambda.Compile();
    }

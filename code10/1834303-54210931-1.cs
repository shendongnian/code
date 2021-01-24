    public static FilterDelegate<T> CreateDelegate<T>(Expression<Func<T, double>> expression)
    {
        var parameter = Expression.Parameter(typeof(IEnumerable<T>), "source");
        // Your `GetMethod` for OrderByDescending did not work for me,
        // so I'll just hand wave about this.
        var orderByDescMethod = typeof(Enumerable)
            .GetMethods()
            .Single(m => m.Name == nameof(Enumerable.OrderByDescending) &&
                         m.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(T), typeof(double));
        var toArrayMethod = typeof(Enumerable)
            .GetMethod(nameof(Enumerable.ToArray))
            .MakeGenericMethod(typeof(T));
        var orderByExpression = Expression.Call(orderByDescMethod, parameter, expression);
        var lambdaBody = Expression.Call(toArrayMethod, orderByExpression);
        var lambdaExpression = Expression.Lambda<FilterDelegate<T>>(lambdaBody, parameter);
        return lambdaExpression.Compile();
    }

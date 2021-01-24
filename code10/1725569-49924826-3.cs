    static Expression<Func<T, bool>> InExpression<T>(
        string propertyName, IEnumerable<int> array)
    {
        var p = Expression.Parameter(typeof(T), "x");
        var contains = typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Single(x => x.Name == "Contains" && x.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(int));
        var property = Expression.PropertyOrField(p, propertyName);
        var body = Expression.Call(contains, Expression.Constant(array), property);
        return Expression.Lambda<Func<T, bool>>(body, p);
    }

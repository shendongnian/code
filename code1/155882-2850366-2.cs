    static LambdaExpression CreateLambda(Type type)
    {
        var source = Expression.Parameter(
            typeof(IEnumerable<>).MakeGenericType(type), "source");
        var call = Expression.Call(
            typeof(Enumerable), "Last", new Type[] { type }, source);
        return Expression.Lambda(call, source)
    }

    private Func<string, List<object>> SelectByType()
    {
        var myContext = Expression.Constant(context);
        var entityTypeName = Expression.Parameter(typeof(string), "entityTypeName");
        var label = Expression.Label(typeof(List<object>));
        var body = Expression.Block(typeof(MyContext).GetProperties()
            .Where(p => typeof(IQueryable).IsAssignableFrom(p.PropertyType) && p.PropertyType.IsGenericType)
            .ToDictionary(
                k => Expression.Constant(k.PropertyType.GetGenericArguments().First().Name),
                v => Expression.Call(typeof(Enumerable), "ToList", new[] {typeof(object)}, Expression.Property(myContext, v.Name))
            )
            .Select(kv =>
                Expression.IfThen(Expression.Equal(kv.Key, entityTypeName),
                  Expression.Return(label, kv.Value))
            )
            .Concat(new Expression[]
            {
                Expression.Throw(Expression.New(typeof(Exception))),
                Expression.Label(label, Expression.Constant(null, typeof(List<object>))),
            })
        );
        var lambda = Expression.Lambda<Func<string, List<object>>>(body, entityTypeName);
        return lambda.Compile();
    }

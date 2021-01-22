    static void Main()
    {
        // try to do "x + (3 * x)"
        var single = BuildSingle<decimal>();
        var composite = BuildComposite<decimal>();
        Console.WriteLine("{0} vs {1}", single(13.2M), composite(13.2M));
    }
    // utility method to get the 3 as the correct type, since there is not always a "int x T"
    static Expression ConvertConstant<TSource, TDestination>(TSource value)
    {
        return Expression.Convert(Expression.Constant(value, typeof(TSource)), typeof(TDestination));
    }
    // option 1: a single expression tree; this is the most efficient
    static Func<T,T> BuildSingle<T>()
    {        
        var param = Expression.Parameter(typeof(T), "x");
        Expression body = Expression.Add(param, Expression.Multiply(
            ConvertConstant<int, T>(3), param));
        var lambda = Expression.Lambda<Func<T, T>>(body, param);
        return lambda.Compile();
    }
    // option 2: nested expression trees:
    static Func<T, T> BuildComposite<T>()
    {
        
        // step 1: do the multiply:
        var paramInner = Expression.Parameter(typeof(T), "inner");
        Expression bodyInner = Expression.Multiply(
            ConvertConstant<int, T>(3), paramInner);
        var lambdaInner = Expression.Lambda(bodyInner, paramInner);
        // step 2: do the add, invoking the existing tree
        var paramOuter = Expression.Parameter(typeof(T), "outer");
        Expression bodyOuter = Expression.Add(paramOuter, Expression.Invoke(lambdaInner, paramOuter));
        var lambdaOuter = Expression.Lambda<Func<T, T>>(bodyOuter, paramOuter);
        return lambdaOuter.Compile();
    }

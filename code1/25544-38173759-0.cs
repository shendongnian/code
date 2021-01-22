    static Func<object> ArrayCreateInstance(Type type, params int[] bounds) // can be generic too
    {
        var ctor = type
            .GetConstructors()
            .OrderBy(x => x.GetParameters().Length) // find constructor with least parameters
            .First();
        var argsExpr = bounds.Select(x => Expression.Constant(x)); // set size
        return Expression.Lambda<Func<object>>(Expression.New(ctor, argsExpr)).Compile();
    }

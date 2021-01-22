    public static D GetMethodAccessor<D>(MethodInfo mi) where D : class
    {
        Type[] args = typeof(D).GetGenericArguments();
        if (args.Length == 0)
            throw new ArgumentException("Type argument D must be generic.");
    
        Type instanceType = args[0];
        // If return type is not null, use one less arg
        bool isAction = mi.ReturnType == typeof(void);
        int callArgCount = args.Length - (isAction ? 1 : 2);
        Type[] argTypes = args.Skip(1).Take(callArgCount).ToArray();
    
        var param = Expression.Parameter(instanceType, "obj");
        var arguments = argTypes.Select((t, i) => Expression.Parameter(t, "p" + i))
                                .ToArray();
        var invoke = Expression.Call(param, mi, arguments);
        var lambda = Expression.Lambda<D>(invoke,
                         Enumerable.Repeat(param, 1).Concat(arguments));
    
        Debug.WriteLine(lambda.Body);
        return lambda.Compile();
    }

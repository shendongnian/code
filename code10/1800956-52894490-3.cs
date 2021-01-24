    public static Func<TService, TInput, TReturn>
        CreateTypedLambdaExpression<TService, TInput, TReturn>(
            string methodName)
    {
        var inputServiceType = typeof(TService);
        var methodInfo = inputServiceType.GetMethod(methodName);
        var inputType = typeof(TInput);
        // now you need to check if TInput is equal to methodInfo.GetParameters().First().ParameterType
        // same check for return type
        var instance = Expression.Parameter(inputServiceType, "serviceInstance");
        var input = Expression.Parameter(inputType, "inputData");
        var call = Expression.Call(instance, methodInfo, input);
        var lambdaFunc = Expression.Lambda<Func<TService, TInput, TReturn>>(call, instance, input);
        return lambdaFunc.Compile();
    }

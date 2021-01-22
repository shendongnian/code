    private static Action<MethodInfo, object> BuildAccessor(Type valueType)
    {
        MethodInfo genericMethod = null; // <-- fill this in
        MethodInfo method = genericMethod.MakeGenericMethod(new Type[] { valueType });
        ParameterExpression methodInfo = Expression.Parameter(typeof(MethodInfo), "methodInfo");
        ParameterExpression obj = Expression.Parameter(typeof(object), "obj");
        Expression<Action<MethodInfo, object>> expr =
            Expression.Lambda<Action<MethodInfo, object>>(
                Expression.Call(method, methodInfo, Expression.Convert(obj, valueType)),
                methodInfo,
                obj);
        return expr.Compile();
    }

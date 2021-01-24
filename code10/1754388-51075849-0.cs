    static Expression ParseOrConvert(ParameterExpression strArray, ConstantExpression index, ParameterInfo paramInfo)
    {
        Type paramType = paramInfo.ParameterType;
        Expression paramValue = Expression.ArrayIndex(strArray, index);
        MethodInfo parseMethod = paramType.GetMethod("Parse", new[] { typeof(string) });
        var isPrimitive = Expression.Constant(paramType.IsPrimitive);
        var call = Expression.Call(parseMethod, paramValue);
        var convert = Expression.Convert(paramValue, paramType);
        var paramValue2 = Expression.Condition(
            isPrimitive,
            call,
            convert
        );
        return paramValue2;
    }

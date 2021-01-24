    NewExpression left = Expression.New(typeof(A));
    NewExpression right = Expression.New(typeof(B));
    ParameterExpression parameterExpression = Expression.Parameter(typeof(A), "p");
    UnaryExpression body = Expression.Convert(
        parameterExpression, typeof(B),
        (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/));
    ParameterExpression[] obj = new ParameterExpression[1];
    obj[0] = parameterExpression;
    Expression.Lambda<Func<B>>(
        Expression.Coalesce(left, right, Expression.Lambda(body, obj)), Array.Empty<ParameterExpression>());

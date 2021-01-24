    private static Expression<Func<Foo, bool>> InExpression<T>(string propertyName, IEnumerable<int> array)
    {
        ExpressionState state = new ExpressionState();
        state.array = array;
        ParameterExpression parameterExpression = Expression.Parameter(typeof(Foo), "x");
        MethodInfo contains = typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Single(x => x.Name == nameof(Enumerable.Contains) && x.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(int));
        Expression[] callArgs = new Expression[2];
        callArgs[0] = Expression.Field(Expression.Constant(state, typeof(ExpressionState)), nameof(ExpressionState.array));
        callArgs[1] = Expression.Property(parameterExpression, propertyName);
        Expression body = Expression.Call(null, contains, callArgs);
        ParameterExpression[] parameters = new ParameterExpression[1];
        parameters[0] = parameterExpression;
        return Expression.Lambda<Func<Foo, bool>>(body, parameters);
    }

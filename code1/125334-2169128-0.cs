    private static Func<object, object> BuildAccessor(MethodInfo method)
    {
        ParameterExpression obj = Expression.Parameter(typeof(object), "obj");
        Expression<Func<object, object>> expr =
            Expression.Lambda<Func<object, object>>(
                Expression.Convert(
                    Expression.Call(
                        Expression.Convert(obj, method.DeclaringType),
                        method),
                    typeof(object)),
                obj);
        return expr.Compile();
    }

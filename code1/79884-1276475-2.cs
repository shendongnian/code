    private static Action<object, object> BuildSetter(FieldInfo field)
    {
        ParameterExpression instance = Expression.Parameter(typeof(object), "instance");
        ParameterExpression value = Expression.Parameter(typeof(object), "value");
        Expression<Action<object, object>> expr =
            Expression.Lambda<Action<object, object>>(
                Expression.Assign(
                    Expression.Field(Expression.Convert(instance, field.DeclaringType), field),
                    Expression.Convert(value, field.FieldType)),
                instance,
                value);
        return expr.Compile();
    }

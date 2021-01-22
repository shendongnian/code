    private Action<object, object> CreateSetter(FieldInfo field)
    {
        var instance = Expression.Parameter(typeof(object));
        var value = Expression.Parameter(typeof(object));
        var body =
            Expression.Block(typeof(void),
                Expression.Assign(
                    Expression.Field(
                        Expression.Unbox(instance, field.DeclaringType),
                        field),
                    Expression.Convert(value, field.FieldType)));
        return (Action<object, object>)Expression.Lambda(body, instance, value).Compile();
    }

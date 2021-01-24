    public static Expression<Func<T, object>> ToMemberOf<T>(this string name) where T : class
    {
        var parameter = Expression.Parameter(typeof(T), "e");
        var propertyOrField = Expression.PropertyOrField(parameter, name);
        var unaryExpression = Expression.MakeUnary(ExpressionType.Convert, propertyOrField, typeof(object));
    
        return Expression.Lambda<Func<T, object>>(unaryExpression, parameter);
    }

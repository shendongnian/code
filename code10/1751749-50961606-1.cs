    public static Expression<Func<T, bool>> MakeExpression<T>(DateTime myDateField)
    {
        ConstantExpression argument = Expression.Constant(myDateField, typeof(DateTime));
        ParameterExpression parameter = Expression.Parameter(typeof(T), "p");
        string propertyName = "Date";
        Expression property = Expression.Property(parameter, propertyName);
        Expression propertyHasvalue = Expression.Property(property, "HasValue");
        Expression propertyValue = Expression.Property(property, "Value");
        Expression date = Expression.Property(propertyValue, "Date");
        ConditionalExpression ternary = Expression.Condition(Expression.Not(propertyHasvalue), Expression.Constant(null, typeof(DateTime?)), Expression.Convert(date, typeof(DateTime?)));
        Expression equalExp = Expression.Equal(ternary, Expression.Convert(argument, typeof(DateTime?)));
        var lambda = Expression.Lambda<Func<T, bool>>(equalExp, parameter);
        lambda.Compile();
        return lambda;
    }

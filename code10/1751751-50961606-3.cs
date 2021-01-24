    public static Expression<Func<T, bool>> MakeExpression<T>(DateTime myDateField)
    {
        ConstantExpression argument = Expression.Constant(myDateField, typeof(DateTime));
        ParameterExpression parameter = Expression.Parameter(typeof(T), "p");
        string propertyName = "Date";
        Expression property = Expression.Property(parameter, propertyName);
        Expression propertyHasvalue = Expression.Property(property, nameof(Nullable<DateTime>.HasValue));
        Expression propertyValue = Expression.Property(property, nameof(Nullable<DateTime>.Value));
        Expression propertyValueDate = Expression.Property(propertyValue, nameof(DateTime.Date));
        ConditionalExpression ternary = Expression.Condition(Expression.Not(propertyHasvalue), Expression.Constant(null, typeof(DateTime?)), Expression.Convert(propertyValueDate, typeof(DateTime?)));
        Expression argumentDate = Expression.Property(argument, nameof(DateTime.Date));
        Expression equalExp = Expression.Equal(ternary, Expression.Convert(argumentDate, typeof(DateTime?)));
        var lambda = Expression.Lambda<Func<T, bool>>(equalExp, parameter);
        return lambda;
    }

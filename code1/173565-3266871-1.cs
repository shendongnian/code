    var parameter = Expression.Parameter(typeof(TableName), "t");
    Expression condition = Expression.Equal(
        Expression.Property(parameter, "Column1"),
        Expression.Constant(value1)));
    if (NeedsToBeIncluded(value2))
    {
        condition = Expression.OrElse(
            condition,
            Expression.Equal(
                Expression.Property(parameter, "Column2"),
                Expression.Constant(value2)));
    }
    var expression = Expression.Lambda<Func<TableName, Boolean>>(condition, parameter);
    var query = context.TableName.Where(expression);

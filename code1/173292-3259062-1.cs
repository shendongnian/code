    var parameter = Expression.Parameter(typeof(String), "employee");
    Expression condition = Expression.Constant(false);
    foreach (var state in states)
    {
        condition = Expression.Or(
            condition,
            Expression.Equal(
                Expression.Property(parameter, "State"),
                Expression.Constant(state)));
    }
            
    var expression = Expression.Lambda<Func<Employee, Boolean>>(condition, parameter);

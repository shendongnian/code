    var parameter = Expression.Parameter(typeof(Employee), "employee");
    Expression condition = Expression.Constant(false);
    foreach (var state in states)
    {
        condition = Expression.OrElse(
            condition,
            Expression.Equal(
                Expression.Property(parameter, "State"),
                Expression.Constant(state)));
    }
            
    var expression = Expression.Lambda<Func<Employee, Boolean>>(condition, parameter);

        ParameterExpression name = Expression.Parameter(typeof(string), "name"),
            value = Expression.Parameter(typeof(string), "value");
        // build in reverse
        Expression body = Expression.Constant(false);
        body = Expression.Condition(
            Expression.AndAlso(
                Expression.Equal(name, Expression.Constant("GAS")),
                Expression.Equal(value, Expression.Constant("G"))
            ), Expression.Constant(true), body);
        body = Expression.Condition(
            Expression.Equal(name, Expression.Constant("MV")),
            Expression.Constant(true), body);
        Expression<Func<string, string, bool>> featureEnabledExpTree =
            Expression.Lambda<Func<string, string, bool>>(body, name, value);
        // test in isolation
        var featureEnabledFunc = featureEnabledExpTree.Compile();
        bool isMatch1 = featureEnabledFunc("MV", "")
            && featureEnabledFunc("GAS", "G") || !featureEnabledFunc("GAS", "F");

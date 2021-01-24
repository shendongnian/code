    private static Expression<Func<int>> ActuallyInnerAlsoCompile()
    {
        var strType = typeof(string);
        var intType = typeof(int);
        var enumearbleType = typeof(Enumerable);
        var array = Expression.NewArrayInit(strType, Expression.Constant("test"), Expression.Constant("test2"));
        var x = Expression.Parameter(strType, "whereParam");
        var whereExp = Expression.Call(enumearbleType,
            "Where",
            new[] {strType},
            array,
            Expression.Lambda(Expression.NotEqual(Expression.PropertyOrField(x, "Length"), Expression.Constant(4)), x));
        var selectExp = Expression.Call(enumearbleType,
            "Select",
            new[] {strType, intType},
            whereExp,
            Expression.Lambda(Expression.PropertyOrField(x, "Length"), x));
        var firstOrDefault = Expression.Call(enumearbleType,
            "FirstOrDefault",
            new[] {intType},
            selectExp);
        return Expression.Lambda<Func<int>>(firstOrDefault);
    }

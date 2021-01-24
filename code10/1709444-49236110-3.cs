    var queryableData = MediusDataContext.MEDSU1s;
    var table = Expression.Parameter(typeof(MEDSU1s), "x");
    var suppCol = Expression.Property(table, typeof(string), "S1SUPP");
    var compCol = Expression.Property(table, typeof(string), "S1COMP");
    Expression condition = Expression.Equal(Expression.Constant(1), Expression.Constant(0));
    foreach (var x in keys)
    {
        var key1 = Expression.Equal(suppCol, Expression.Constant(x.SUPP));
        var key2 = Expression.Equal(compCol, Expression.Constant(x.COMP));
        var both = Expression.AndAlso(key1, key2);
        condition = Expression.OrElse(condition, both);
    }
    
    var whereExpression = Expression.Call(
        typeof(Queryable),
        "Where",
        new Type[] { queryableData.ElementType },
        queryableData.Expression,
        Expression.Lambda<Func<MEDSU1s, bool>>(
            condition, 
            new ParameterExpression[] { table }));
    
    var medusFromSql = queryableData.Provider.CreateQuery<MEDSU1s>(whereExpression).ToList();
    

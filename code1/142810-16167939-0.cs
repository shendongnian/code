    var miSqlPatIndex = typeof(SqlFunctions).GetMethod(
        "PatIndex", 
        BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase, 
        null, 
        new Type[] { typeof(string), typeof(string) }, 
        null);                        
    expr = Expression.GreaterThan(
        Expression.Call(
            miSqlPatIndex, 
            new Expression[] { Expression.Constant("%123%ABC"), MySearchField }),
            Expression.Convert(Expression.Constant(0), typeof(int?)));
    

    public static Expression<Func<MyCustomClass, bool>> GetExpression(
        string derrivedName, // "Product" or "Country"
        int fieldId,
        string value)
    {
        var x = Expression.Parameter(typeof(MyCustomClass), "x");
        var lambda = Expression.Lambda<Func<MyCustomClass, bool>>(
            Expression.Equal(
                Expression.Constant(value),
                Expression.PropertyOrField(
                    Expression.PropertyOrField(x, derrivedName),
                    $"Field{fieldId}")
                ), 
                x);
        
        return lambda;
    }
    

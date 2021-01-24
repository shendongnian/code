    public static Expression<Func<T, T, bool>> CreateAreEqualExpression<T>(params string[] toExclude)
    {
        var type = typeof(T);
        var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => !toExclude.Contains(p.Name))
            .ToArray();
        var p1 = Expression.Parameter(type, "p1");
        var p2 = Expression.Parameter(type, "p2");
        Expression body = null;
        foreach (var property in props)
        {
            var pare = Expression.Equal(
                Expression.PropertyOrField(p1, property.Name),
                Expression.PropertyOrField(p2, property.Name)
            );
            body = body == null ? pare : Expression.AndAlso(body, pare);
        }
        if (body == null) // all properties are excluded
            body = Expression.Constant(true);
        var lambda = Expression.Lambda<Func<T, T, bool>>(body, p1, p2);
        return lambda;
    }
    

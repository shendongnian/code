    private static IQueryable<T> DynamicOrderBy<T>(
        IQueryable<T> source,
        string sortProperty,
        Dictionary<string, Expression> map)
    {
        var type = typeof(T);
        var parameter = Expression.Parameter(type, "p");
        var property = type.GetProperty(sortProperty, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        Expression whereLambda;
        if (!map.TryGetValue($"{type.Name}.{sortProperty}", out whereLambda))
        {
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            whereLambda = Expression.Lambda(propertyAccess, parameter);
        }
        // else we just using a lambda from map
        // call OrderBy
        var query = Expression.Call(
            typeof(Queryable),
            "OrderBy",
            new[] {type, property.PropertyType},
            source.Expression,
            whereLambda
        );
        return source.Provider.CreateQuery<T>(query);
    }

    private static IEnumerable<T> GetSortedData<T>(IQueryable<T> list, string sortColumnName) 
    { 
        var type = typeof(T); 
        var property = type.GetProperty(sortColumnName); 
        var parameter = Expression.Parameter(type, "p"); 
        var propertyAccess = Expression.Property(parameter, property); 
        var orderByExp = Expression.Lambda(propertyAccess, parameter); 
        MethodCallExpression resultExp = Expression.Call(typeof(Queryable), "OrderBy", new[] { type, property.PropertyType }, list.Expression, Expression.Quote(orderByExp)); 
        return (IEnumerable<T>)Expression.Lambda(resultExp).Compile().DynamicInvoke(); 
    } 

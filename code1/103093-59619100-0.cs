    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering, bool descending)
    {
        var type = typeof(T);
        var property = type.GetProperty(ordering);
        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExp = Expression.Lambda(propertyAccess, parameter);
        MethodCallExpression resultExp = 
            Expression.Call(typeof(Queryable), (descending ? "OrderByDescending" : "OrderBy"), 
                new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
        return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(resultExp);
    }

    public static IEnumerable<T> WhereAny<T, U>(
        this IEnumerable<T> ListToFilter, string PropertyToFilterOn, List<U> FilterValues)
    {
        ParameterExpression p = Expression.Parameter(typeof(T), "x");
        var methodCall = Expression.Call(            
            Expression.Constant(FilterValues, typeof(List<U>)),
            typeof(List<U>).GetMethod("Contains"),
            Expression.PropertyOrField(p, PropertyToFilterOn)
        );
        return ListToFilter.Where(Expression.Lambda<Func<T,bool>>(methodCall, p).Compile());
    }

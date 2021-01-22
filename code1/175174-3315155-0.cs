    private static IOrderedEnumerable<T> SortEngine<T>(this IEnumerable<T> source, string columnName, bool isAscending, bool started)
    {
        var item = Expression.Parameter(typeof(T), "item");
        var propertyValue = Expression.PropertyOrField(item, columnName);
        var propertyLambda = Expression.Lambda(propertyValue, item);
        // item => item.{columnName}
        
        var sourceExpression = Expression.Parameter(typeof(IEnumerable<T>), "source");
    
        string methodName;
        Expression inputExpression;
        if (started)
        {
            methodName = isAscending ? "ThenBy" : "ThenByDescending";
            inputExpression = Expression.Convert(sourceExpression, typeof(IOrderedEnumerable<T>));
            // ThenBy requires input to be IOrderedEnumerable<T>
        }
        else
        {
            methodName = isAscending ? "OrderBy" : "OrderByDescending";
            inputExpression = sourceExpression;
        }
    
        var sortTypeParameters = new Type[] { typeof(T), propertyValue.Type };
        var sortExpression = Expression.Call(typeof(Enumerable), methodName, sortTypeParameters, inputExpression, propertyLambda);
        var sortLambda = Expression.Lambda<Func<IEnumerable<T>, IOrderedEnumerable<T>>>(sortExpression, sourceExpression);
        // source => Enumerable.OrderBy<T, TKey>(source, item => item.{columnName})
        
        return sortLambda.Compile()(source);
    }
    
    public static IOrderedEnumerable<T> OrderBy<T>(this IEnumerable<T> source, string columnName)
    {
        return SortEngine(source, columnName, true, false);
    }
    
    public static IOrderedEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source, string columnName)
    {
        return SortEngine(source, columnName, false, false);
    }
    
    public static IOrderedEnumerable<T> ThenBy<T>(this IOrderedEnumerable<T> source, string columnName)
    {
        return SortEngine(source, columnName, true, true);
    }
    
    public static IOrderedEnumerable<T> ThenByDescending<T>(this IOrderedEnumerable<T> source, string columnName)
    {
        return SortEngine(source, columnName, false, true);
    }

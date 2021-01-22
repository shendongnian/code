    public static IQueryable<T> Where<T>(this IQueryable<T> source, 
                                              IEnumerable<Filter> filters)
    {
        return Queryable.Where(source, CreateFilterExpression<T>(filters));
    }

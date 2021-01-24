    public static IQueryable<T> SortByField<T, TKey>(this IQueryable<T> source, Expression<Func<T, TKey>> selector, bool ascending = true)
    {
        return ascending ? source.OrderBy(selector) : source.OrderByDescending(selector);
    }
    public static IQueryable<T> SortByField<T, TKey>(this IQueryable<T> source, Expression<Func<T, TKey>> selector, string order = "asc")
    {
        return SortByField(source, selector, order.Equals("asc", StringComparison.OrdinalIgnoreCase)); //condition here can be improved, just as a sample of how to do it
    }

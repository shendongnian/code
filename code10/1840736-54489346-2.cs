    public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, NameValueCollection filters)
            where T : class
    {
        if (filters.Count < 1)
            return collection;
        return collection.Where(x => x.InnerFilter(filters));
    }

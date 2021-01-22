    public static IEnumerable<IEnumerable<T>> Split<T>(this ICollection<T> items, 
                                                       int numOfParts)
    {
        return Enumerable.Range(0, Math.Min(items.Count, numOfParts))
                         .Select(x => items.Where((item, index) => (index % numOfParts) == x));
    }

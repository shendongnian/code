    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> items, 
                                                       int numOfParts)
    {
        return Enumerable.Range(0, numOfParts).Select(x => items.Where((item, index) => (index % numOfParts) == x));
    }

    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> items, 
                                                       int numberOfChunks)
    {
        int i = 0;
        return items.GroupBy(x => i++ % numOfParts);
    }

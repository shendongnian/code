    public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> items, 
                                                           int partitionSize)
    {
        int i = 0;
        return items.GroupBy(x => i++ / partitionSize).ToArray();
    }

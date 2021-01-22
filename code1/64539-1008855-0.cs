    public static IEnumerable<IEnumerable<T>> Split<T>(
        this IEnumerable<T> list, int partSize)
    {
        int i = 0;
        var splits = from name in list
                     group name by i++ / partSize into part
                     select part.AsEnumerable();
        return splits;
    }

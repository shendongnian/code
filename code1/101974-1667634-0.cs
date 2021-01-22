    public static ICollection<T> AddTo<T>(this IEnumerable<T> list,
                                          ICollection<T> collection)
    {
        foreach (T item in list)
        {
            collection.Add(item);
        }
        return collection;
    }

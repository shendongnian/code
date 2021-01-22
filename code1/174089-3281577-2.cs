    public static void Traverse<T>(this IEnumerable<T> items,
                                   Action<T> action,
                                   Func<T, IEnumerable<T>> childrenProvider)
    {
        foreach (T item in items)
        {
            action(item);
            Traverse<T>(childrenProvider(item), action, childrenProvider);
        }
    }

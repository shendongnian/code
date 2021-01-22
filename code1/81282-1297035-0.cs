    private static T FindInCollection<T>(ICollection<T> collection, Predicate<T> match)
    {
        foreach (T item in collection)
        {
            if (match(item))
                return item;
        }
        return default(T);
    }

    public static IEnumerable<IEnumerable<T>> Test<T>(IEnumerable<T> source)
    {
        var items = new List<T>();
        foreach (T item in source)
        {
            items.Add(item);
            if (!SomePredicate(item))
            {
                yield return items;
                items = new List<T>();
            }
        }
        // if you want any remaining items to go into their own IEnumerable, even if there's no more fails
        if (items.Count > 0)
        {
            yield return items;
        }
    }

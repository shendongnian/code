    public static void RemoveSingle<T>(this List<T> items, Predicate<T> match)
    {
        int i = -1;
        while (i < items.Count && !match(items[++i])) ;
        if (i < items.Count)
        {
            items[i] = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
        }
    }

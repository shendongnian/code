    public static IEnumerable<T> Intersperse<T>(this IEnumerable<T> enumerable, T item)
    {
        bool first = true;
        foreach (T value in enumerable)
        {
            if (!first) yield return item;
            yield return value;
            first = false;
        }
    }
            

    public static IEnumerable<T> Intersperse<T>(this IEnumerable<T> collection, T value)
    {
        foreach(T item in collection)
        {
            yield return item;
            yield return value;
        }
        
        yield break;
    }

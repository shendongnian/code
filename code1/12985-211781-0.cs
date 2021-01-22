    public static IEnumerable<T> OfType<T>(this IEnumerable list)
    {
        foreach (var obj in list)
        {
            if (obj is T)
                yield return (T)obj;
        }
    }

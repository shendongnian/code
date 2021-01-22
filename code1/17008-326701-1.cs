    public static IEnumerable<T> Add<T>(this IEnumerable<T> enumerable, T newItem)
    {
        List<T> result = new List<T>(enumerable);
        result.Add(newItem);
        return result;
    }
    
    public static IEnumerable<T> Add<T>(this IEnumerable<T> enumerable, params T[] newItems)
    {
        List<T> result = new List<T>(enumerable);
        result.AddRange(newItems);
        return result;
    }

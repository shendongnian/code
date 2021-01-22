    public static bool ContainsAny<T>(this IEnumerable<T> data,
        IEnumerable<T> intersection)
    {
        foreach(T item in intersection)
            if(data.Contains(item)
                return true;
        return false;
    }
    public static bool ContainsAll<T>(this IEnumerable<T> data,
        IEnumerable<T> intersection)
    {
        foreach(T item in intersection)
            if(!data.Contains(item))
                return false;
        return true;
    }

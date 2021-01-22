    /// <summary>
    /// Wrap an object in a list
    /// </summary>
    public static IList<T> WrapInList<T>(this T item)
    {
        List<T> result = new List<T>();
        result.Add(item);
        return result;
    }

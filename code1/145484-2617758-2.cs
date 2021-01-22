    /// <summary>
    /// A better ToString for Enumerable objects (mostly for logging)
    /// </summary>
    public static string ToStringList<T>(this IEnumerable<T> collection, int limit)
    {
        return string.Join(", ", collection.Take(limit));
    }

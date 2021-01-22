    /// <summary>
    /// A better ToString for Enumerable objects (mostly for logging)
    /// </summary>
    public static string ToStringList(this IEnumerable<string> collection, int limit)
    {
        return string.Join(", ", collection.Take(limit));
    }

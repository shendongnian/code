    /// <summary>
    /// Distinct method that accepts a perdicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">The source.</param>
    /// <param name="predicate">The predicate.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    public static IEnumerable<T> DistinctBy<T>
        (this IEnumerable<T> source,
         Func<T, bool> predicate)
    {
        if (source == null)
            throw new ArgumentNullException("source");
         return source
            .GroupBy(predicate)
            .Select(x => x.First());
    }

    /// <summary>
    /// Distinct method that accepts a perdicate
    /// </summary>
    /// <typeparam name="TSource">The type of the t source.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    /// <param name="source">The source.</param>
    /// <param name="predicate">The predicate.</param>
    /// <returns>IEnumerable&lt;TSource&gt;.</returns>
    /// <exception cref="System.ArgumentNullException">source</exception>
    public static IEnumerable<TSource> DistinctBy<TSource, TKey>
        (this IEnumerable<TSource> source,
         Func<TSource, TKey> predicate)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        return source
            .GroupBy(predicate)
            .Select(x => x.First());
    }

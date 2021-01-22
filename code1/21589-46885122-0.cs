    /// <summary>
    /// Determines whether a sequence contains the specified elements by using the default equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">A sequence in which to locate the values.</param>
    /// <param name="values">The values to locate in the sequence.</param>
    /// <returns>true if the source sequence contains elements that have the specified values; otherwise, false.</returns>
    public static bool ContainsAll<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> values)
    {
        return !values.Except(source).Any();
    }

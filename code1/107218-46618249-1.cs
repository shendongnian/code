    /// <summary>
    /// Skips first element of an IEnumerable
    /// </summary>
    /// <typeparam name="U">Enumerable type</typeparam>
    /// <param name="models">The enumerable</param>
    /// <returns>IEnumerable of type skipping first element</returns>
    private IEnumerable<U> SkipFirstEnumerable<U>(IEnumerable<U> models)
    {
        using (var e = models.GetEnumerator())
        {
            if (!e.MoveNext()) return;
            for (;e.MoveNext();) yield return e.Current;
            yield return e.Current;
        }
    }
    /// <summary>
    /// Skips last element of an IEnumerable
    /// </summary>
    /// <typeparam name="U">Enumerable type</typeparam>
    /// <param name="models">The enumerable</param>
    /// <returns>IEnumerable of type skipping last element</returns>
    private IEnumerable<U> SkipLastEnumerable<U>(IEnumerable<U> models)
    {
        using (var e = models.GetEnumerator())
        {
            if (!e.MoveNext()) return;
            yield return e.Current;
            for (;e.MoveNext();) yield return e.Current;
        }
    }

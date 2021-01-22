    /// <summary>
    /// Skips first element of an IEnumerable
    /// </summary>
    /// <typeparam name="U">Enumerable type</typeparam>
    /// <param name="models">The enumerable</param>
    /// <returns>IEnumerable of type skipping first element</returns>
    private IEnumerable<U> SkipFirstEnumerable<U>(IEnumerable<U> models)
    {
        bool first = false;
        foreach(U m in models)
        {
            if(!first)
            {
                first = true;
                continue;
            }
            yield return m;
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
        bool last = false;
        var rollit = models.GetEnumerator();
        while (!last)
        {
            var current = rollit.Current;
            last = !rollit.MoveNext();
            yield return current;
        }
    }

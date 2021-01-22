    private static IEnumerable<T> CheapDistinct<T>(IEnumerable<T> source)
    {
        return CheapDistinct<T>(source, Comparer<T>.Default);
    }
    private static IEnumerable<T> CheapDistinct<T>(IEnumerable<T> source,
        IComparer<T> comparer)
    {
        #region Parameter Validation
        if (Object.ReferenceEquals(null, source))
            throw new ArgumentNullException("source");
        if (Object.ReferenceEquals(null, comparer))
            throw new ArgumentNullException("comparer");
        #endregion
        using (IEnumerator<T> enumerator = source.GetEnumerator())
        {
            if (enumerator.MoveNext())
            {
                T item = enumerator.Current;
                // scan until different item found, then produce
                // the previous distinct item
                while (enumerator.MoveNext())
                {
                    if (comparer.Compare(item, enumerator.Current) != 0)
                    {
                        yield return item;
                        item = enumerator.Current;
                    }
                }
                // produce last item that is left over from above loop
                yield return item;
            }
        }
    }

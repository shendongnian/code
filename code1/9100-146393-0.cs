    private static IEnumerable<T> Merge<T>(IEnumerable<T> source1,
        IEnumerable<T> source2)
    {
        return Merge(source1, source2, Comparer<T>.Default);
    }
    private static IEnumerable<T> Merge<T>(IEnumerable<T> source1,
        IEnumerable<T> source2, IComparer<T> comparer)
    {
        #region Parameter Validation
        if (Object.ReferenceEquals(null, source1))
            throw new ArgumentNullException("source1");
        if (Object.ReferenceEquals(null, source2))
            throw new ArgumentNullException("source2");
        if (Object.ReferenceEquals(null, comparer))
            throw new ArgumentNullException("comparer");
		
	    #endregion
        using (IEnumerator<T>
            enumerator1 = source1.GetEnumerator(),
            enumerator2 = source2.GetEnumerator())
        {
            Boolean more1 = enumerator1.MoveNext();
            Boolean more2 = enumerator2.MoveNext();
            while (more1 && more2)
            {
                Int32 comparisonResult = comparer.Compare(
                    enumerator1.Current,
                    enumerator2.Current);
                if (comparisonResult < 0)
                {
                    // enumerator 1 has the "lowest" item
                    yield return enumerator1.Current;
                    more1 = enumerator1.MoveNext();
                }
                else if (comparisonResult > 0)
                {
                    // enumerator 2 has the "lowest" item
                    yield return enumerator2.Current;
                    more2 = enumerator2.MoveNext();
                }
                else
                {
                    // they're considered equivalent, only yield it once
                    yield return enumerator1.Current;
                    more1 = enumerator1.MoveNext();
                    more2 = enumerator2.MoveNext();
                }
            }
            // Yield rest of values from non-exhausted source
            while (more1)
            {
                yield return enumerator1.Current;
                more1 = enumerator1.MoveNext();
            }
            while (more2)
            {
                yield return enumerator2.Current;
                more2 = enumerator2.MoveNext();
            }
        }
    }

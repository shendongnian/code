    static IEnumerable<IEnumerable<T>> Batch<T>(
        this IEnumerable<T> source, 
        int batchCount,
        bool throwOnPartialBatch = false)
    {
        IEnumerable<T> nextBatch(IEnumerator<T> enumerator)
        {
            var counter = 0;
            do
            {
               yield return enumerator.Current;
               counter += 1;
            } while (counter < batchCount && enumerator.MoveNext());
            if (throwOnPartialBatch && counter != batchCount) //numers.Count % batchCount is not zero.
                throw new InvalidOperationException("Invalid batch size.");
        }
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        if (batchCount < 1)
            throw new ArgumentOutOfRangeException(nameof(batchCount));
        using (var e = source.GetEnumerator())
        {
            while (e.MoveNext())
            {
                yield return nextBatch(e);
            }
        }
    }

    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size), "Size must be greater than zero.");
        return BatchImpl(source, size).TakeWhile(x => x.Any());
    }
    static IEnumerable<IEnumerable<T>> BatchImpl<T>(this IEnumerable<T> source, int size)
    {
        var values = new List<T>();
        var group = 1;
        var disposed = false;
        var e = source.GetEnumerator();
        try
        {
            while (!disposed)
            {
                yield return GetBatch(e, values, group, size, () => { e.Dispose(); disposed = true; });
                group++;
            }
        }
        finally
        {
            if (!disposed)
                e.Dispose();
        }
    }
    static IEnumerable<T> GetBatch<T>(IEnumerator<T> e, List<T> values, int group, int size, Action dispose)
    {
        var min = (group - 1) * size + 1;
        var max = group * size;
        var hasValue = false;
        while (values.Count < min && e.MoveNext())
        {
            values.Add(e.Current);
        }
        for (var i = min; i <= max; i++)
        {
            if (i <= values.Count)
            {
                hasValue = true;
            }
            else if (hasValue = e.MoveNext())
            {
                values.Add(e.Current);
            }
            else
            {
                dispose();
            }
            if (hasValue)
                yield return values[i - 1];
            else
                yield break;
        }
    }

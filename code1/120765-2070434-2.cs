    public static IEnumerable<IEnumerable<T>> Transpose<T>(
        this IEnumerable<IEnumerable<T>> source)
    {
        var enumerators = source.Select(e => e.GetEnumerator()).ToArray();
        try
        {
            while (enumerators.All(e => e.MoveNext()))
            {
                yield return enumerators.Select(e => e.Current).ToArray();
            }
        }
        finally
        {
            Array.ForEach(enumerators, e => e.Dispose());
        }
    }

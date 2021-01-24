    [Flags]
    enum PositionFlags
    {
        None = 0,
        First = 1,
        Last = 2
    }    
    public static IEnumerable<(T value, PositionFlags flags)> WithPositions<T>(
        this IEnumerable<T> source)
    {
        using (var enumerator = source.GetEnumerator())
        {
            if (!enumerator.MoveNext())
            {
                yield break;
            }
            T value = enumerator.Current;
            PositionFlags flags = PositionFlags.First;
            while (enumerator.MoveNext())
            {
                yield return (value, flags);
                value = enumerator.Current;
                flags = PositionFlags.None;
            }
            flags |= PositionFlags.Last;
            yield return (value, flags);
        }
    }

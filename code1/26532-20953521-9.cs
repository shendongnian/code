    public static IEnumerable<IEnumerable<T>> Chunkify<T>(this IEnumerable<T> enumerable, 
                                                          int chunkSize)
    {
        if (chunkSize < 1) throw new ArgumentException("chunkSize must be positive");
    
        using (var e = enumerable.GetEnumerator())
            while (e.MoveNext())
                yield return e.GetChunk(chunkSize);
    }
    
    private static IEnumerable<T> GetChunk<T>(this IEnumerator<T> e,
                                              int chunkSize)
    {
        do yield return e.Current; 
        while (--chunkSize > 0 && e.MoveNext());
    }

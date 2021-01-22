    public static IEnumerable<IEnumerable<T>> Chunkify<T>(this IEnumerable<T> enumerable, 
                                                          int chunkSize)
    {
        if (chunkSize < 1) throw new ArgumentException("chunkSize must be positive");
    
        using (var enumerator = enumerable.GetEnumerator())
            while (enumerator.MoveNext())
                yield return enumerator.GetChunk(chunkSize);
    }
    
    private static IEnumerable<T> GetChunk<T>(this IEnumerator<T> enumerator,
                                              int chunkSize)
    {
        do yield return enumerator.Current; 
        while (--chunkSize > 0 && enumerator.MoveNext());
    }

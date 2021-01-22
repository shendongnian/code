    public static IEnumerable<IEnumerable<T>> SplitIntoChunks<T>(this T[] source, int chunkSize)
    {
        var chunks = from index in Enumerable.Range(0, source.Length)
                     group source[index] by index / chunkSize;
    
        return chunks;
    }
    
    public static T[][] SplitIntoArrayChunks<T>(this T[] source, int chunkSize)
    {
        var chunks = from index in Enumerable.Range(0, source.Length)
                     group source[index] by index / chunkSize;
    
        return chunks.Select(e => e.ToArray()).ToArray();
    }

    public static IEnumerable<T[]> Chunk<T>(IEnumerable<T> source, int chunksize)
    {
        var list = source as IList<T> ?? source.ToList();
        for (int start = 0; start < list.Count; start += chunksize)
        {
            T[] chunk = new T[Math.Min(chunksize, list.Count - start)];
            for (int i = 0; i < chunk.Length; i++)
                chunk[i] = list[start + i];
            yield return chunk;
        }
    }

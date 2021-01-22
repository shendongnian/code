    static IEnumerable<T[]> Chunkify<T>(IEnumerable<T> items, int size)
        {
        var chunk = new List<T>(size);
        foreach (T item in items)
            {
            chunk.Add(item);
            if (chunk.Count == size)
                {
                yield return chunk.ToArray();
                chunk.Clear();
                }
            }
        if (chunk.Count > 0)
            {
            yield return chunk.ToArray();
            }
        }

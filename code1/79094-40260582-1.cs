    public static IEnumerable<T[]> GroupToChunks<T>(this IEnumerable<T> items, int chunkSize)
    {
        if (chunkSize <= 0)
        {
            throw new ArgumentException("Chunk size must be positive.", "chunkSize");
        }
        return
            items.Select((item, index) => new { item, index })
                 .GroupBy(pair => pair.index / chunkSize, pair => pair.item)
                 .Select(grp => grp.ToArray());
    }

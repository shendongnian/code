    public static IEnumerable<IEnumerable<T>> Split<T>(this ICollection<T> items, 
                                                       int numberOfChunks)
    {
        if (numberOfChunks <= 0 || numberOfChunks > items.Count)
            throw new ArgumentOutOfRangeException("numberOfChunks");
        int sizePerPacket = items.Count / numberOfChunks;
        int extra = items.Count % numberOfChunks;
        for (int i = 0; i < numberOfChunks - extra; i++)
            yield return items.Skip(i * sizePerPacket).Take(sizePerPacket);
        int alreadyReturnedCount = (numberOfChunks - extra) * sizePerPacket;
        int toReturnCount = extra == 0 ? 0 : (items.Count - numberOfChunks) / extra + 1;
        for (int i = 0; i < extra; i++)
            yield return items.Skip(alreadyReturnedCount + i * toReturnCount).Take(toReturnCount);
    }

    /// <summary>
    /// Clumps items into same size lots.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">The source list of items.</param>
    /// <param name="size">The maximum size of the clumps to make.</param>
    /// <returns>A list of list of items, where each list of items is no bigger than the size given.</returns>
    public static IEnumerable<IEnumerable<T>> Clump<T>(this IEnumerable<T> source, int size)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (size < 1)
            throw new ArgumentOutOfRangeException("size", "size must be greater than 0");
        return ClumpIterator<T>(source, size);
    }
    private static IEnumerable<IEnumerable<T>> ClumpIterator<T>(IEnumerable<T> source, int size)
    {
        Debug.Assert(source != null, "source is null.");
        T[] items = new T[size];
        int count = 0;
        foreach (var item in source)
        {
            items[count] = item;
            count++;
            if (count == size)
            {
                yield return items;
                items = new T[size];
                count = 0;
            }
        }
        if (count > 0)
        {
            if (count == size)
                yield return items;
            else
            {
                T[] tempItems = new T[count];
                Array.Copy(items, tempItems, count);
                yield return tempItems;
            }
        }
    }

    public static IEnumerable<IEnumerable<T>> PartitionBy<T>(this IEnumerable<T> sequence, Func<T, int, bool> predicate)
    {
        var block = new List<T>();
        int index = 0;
        foreach (var item in sequence)
        {
            if (predicate(item, index++))
            {
                block.Add(item);
            }
            else if (block.Count > 0)
            {
                yield return block.ToList(); // Return a copy so the caller can't change our local list.
                block.Clear();
            }
        }
        if (block.Count > 0)
            yield return block; // No need for a copy since we've finished using our local list.
    }

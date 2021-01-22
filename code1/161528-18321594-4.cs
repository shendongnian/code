    public static IEnumerable<TSource> ExceptAll<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
    {
        return ExceptAll(first, second, null);
    }
    public static IEnumerable<TSource> ExceptAll<TSource>(
        this IEnumerable<TSource> first,
        IEnumerable<TSource> second,
        IEqualityComparer<TSource> comparer)
    {
        if (first == null) { throw new ArgumentNullException("first"); }
        if (second == null) { throw new ArgumentNullException("second"); }
        var secondCounts = new Dictionary<TSource, int>(comparer ?? EqualityComparer<TSource>.Default);
        int count;
        int nullCount = 0;
            
        // Count the values from second
        foreach (var item in second)
        {
            if (item == null)
            {
                nullCount++;
            }
            else
            {
                if (secondCounts.TryGetValue(item, out count))
                {
                    secondCounts[item] = count + 1;
                }
                else
                {
                    secondCounts.Add(item, 1);
                } 
            }
        }
        // Yield the values from first
        foreach (var item in first)
        {
            if (item == null)
            {
                nullCount--;
                if (nullCount < 0)
                {
                    yield return item;
                } 
            }
            else
            {
                if (secondCounts.TryGetValue(item, out count))
                {
                    if (count == 0)
                    {
                        secondCounts.Remove(item);
                        yield return item;
                    }
                    else
                    {
                        secondCounts[item] = count - 1;
                    }
                }
                else
                {
                    yield return item;
                }
            }
        }
    }

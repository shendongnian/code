    public static IEnumerable<T> Mode<T>(
        this IEnumerable<T> source,
        IEqualityComparer<T> comparer = null)
    {
        var counts = source.GroupBy(t => t, comparer)
            .Select(g => new { g.Key, Count = g.Count() })
            .ToList();
        var maxes = new List<int>(5);
        int maxCount;
        for (var i = 0; i < counts.Count; i++)
        {
            if (counts[i].Count < maxCount)
            {
                continue;
            }
            if (counts[i].Count > maxCount)
            {
                maxes.Clear();
                continue;
            }
            
            maxes.Add(i);
        }
        return maxes.Select(i => counts[i].Key);
    }

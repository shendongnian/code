    static int CountPairs<T>(IEnumerable<T> source)
    {
        var counter = new Dictionary<T, int>();
        foreach (var item in source)
        {
            if (!counter.TryAdd(item, 1))
                counter[item] += 1;
        }
        var pairs = 0;
        foreach (var count in counter.Values)
        {
            pairs += count / 2;
        }
        return pairs;
    }

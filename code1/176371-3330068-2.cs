    public static IEnumerable<TSource> TakeLargest<TSource, TKey>
        (this IEnumerable<TSource> items, Func<TSource, TKey> selector, int count)
    {
        var set = new SortedDictionary<TKey, List<TSource>>();
        var resultCount = 0;
        foreach (var item in items)
        {
            // If the key is already smaller than the smallest
            // item in the set, we can ignore this item
            var key = selector(item);
            if (!set.Any() ||
                resultCount < count ||
                Comparer<TKey>.Default.Compare(key, set.First().Key) >= 0)
            {
                // Add next item to set
                if (!set.ContainsKey(key))
                {
                    set[key] = new List<TSource>();
                }
                set[key].Add(item);
                // Remove smallest item from set
                resultCount++;
                var first = set.First();
                if (resultCount - first.Value.Count >= count)
                {
                    set.Remove(first.Key);
                    resultCount -= first.Value.Count;
                }
            }
        }
        return set.Values.SelectMany(values => values);
    }

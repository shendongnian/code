    public static void MutateEach(this IDictionary<TKey, TValue> dict, Func<TKey, TValue, KeyValuePair<TKey, TValue>> mutator)
    {
        var removals = new List<TKey>();
        var additions = new List<KeyValuePair<TKey, TValue>>();
        foreach (var pair in dict)
        {
            var newPair = mutator(pair.Key, pair.Value);
            if ((newPair.Key != pair.Key) || (newPair.Value != pair.Value))
            {
                removals.Add(pair.Key);
                additions.Add(newPair);
            }
        }
        foreach (var removal in removals)
            dict.Remove(removal);
        foreach (var addition in additions)
            dict.Add(addition.Key, addition.Value);
    }

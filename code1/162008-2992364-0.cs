    private static void RemoveByValue<TKey,TValue>(Dictionary<TKey, TValue> dictionary, TValue someValue)
    {
        List<TKey> itemsToRemove = new List<TKey>();
        foreach (var pair in dictionary)
        {
            if (pair.Value.Equals(someValue))
                itemsToRemove.Add(pair.Key);
        }
        foreach (TKey item in itemsToRemove)
        {
            dictionary.Remove(item);
        }
    }

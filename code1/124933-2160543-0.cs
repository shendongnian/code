    private ConcurrentDictionary<string, ICollection<int>> _dictionary;
    private static ICollection<int> CreateEmptyList(string dummyKey)
    {
        return new List<int>();
    }
    private void AddValue(string key, int value)
    {
        ICollection<int> values = _dictionary.GetOrAdd(key, CreateEmptyList);
        values.Add(value);
    }

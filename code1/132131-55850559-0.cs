    private static Dictionary<object, object> CreateCopy(IDictionary source)
    {
        var copy = new Dictionary<object, object>(source.Count);
        foreach (DictionaryEntry entry in source)
        {
            copy.Add(entry.Key, entry.Value);
        }
        return copy;
    }

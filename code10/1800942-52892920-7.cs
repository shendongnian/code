    private static IEnumerable<Output> CreateOutput(Input input)
    {
        foreach (string key in input.Keys)
        {
            string aValue = null;
            string bValue = null;
            input.A?.TryGetValue(key, out aValue);
            input.B?.TryGetValue(key, out bValue);
            yield return new Output
            {
                A = aValue,
                B = bValue,
                Key = key
            };
        }
    }

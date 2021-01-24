    private static IEnumerable<Output> CreateOutput(Input input)
    {
        foreach (string key in input.Keys)
        {
            input.A.TryGetValue(key, out string aValue);
            input.B.TryGetValue(key, out string bValue);
            yield return new Output
            {
                A = aValue,
                B = bValue,
                Key = key
            };
        }
    }

    public static IEnumerable<KeyValuePair<ulong, string>> GetValues()
    {
        foreach (var pair in allOffset.Values)
        {
            foreach (var value in pair)
            {
                yield return value;
            }
        }
    }

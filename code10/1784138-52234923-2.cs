    public static IEnumerable<string> GetCombinations(
        string s,
        Dictionary<char, IEnumerable<char>> substitutions)
    {
        IEnumerable<string> GetCombinations(
            string original, 
            string current, 
            int index)
        {
            if (index == original.Length)
            {
                yield return current;
            }
            else
            {
                if (substitutions.TryGetValue(
                    original[index],
                    out var chars))
                {
                    foreach (var c in chars)
                    {
                        foreach (var combination in
                            GetCombinations(original,
                                            current + c,
                                            index + 1))
                        {
                            yield return combination;
                        }
                    }
                }
            }
        }
        if (string.IsNullOrEmpty(s))
            return Enumerable.Repeat(s, 1);
        var lowerCased = s.ToLower();
        return GetCombinations(lowerCased,
                               string.Empty,
                               0);
    }

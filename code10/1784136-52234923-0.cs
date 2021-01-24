    public static IEnumerable<string> GetCombinations(
        string s,
        Dictionary<char, IEnumerable<char>> substitutions)
    {
        IEnumerable<string> GetCombination(
            string original, string current, int index)
        {
            if (index == original.Length)
            {
                yield return current;
            }
            else
            {
                if (substitutions.TryGetValue(
                    original[index], out var chars))
                {
                    foreach (var c in chars)
                    {
                        foreach (var combination in
                            GetCombination(original, 
                                           current + c, 
                                           index + 1))
                            yield return combination;
                    }
                }
            }
        }
        var lowerCasedWord = s.ToLower();
        return GetCombination(lowerCasedWord, "", 0);
    }

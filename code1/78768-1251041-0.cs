    static List<string>[] FindMatches(string[] source, string[] target)
    {
        // Initialize array to hold results
        List<string>[] matches = new List<string>[source.Length];
        for (int i = 0; i < matches.Length; i++)
            matches[i] = new List<string>();
        int s = 0;
        for (int t = 0; t < target.Length; t++)
        {
            while (!MatchName(source[s], target[t]))
            {
                s++;
                if (s >= source.Length)
                    return matches;
            }
            matches[s].Add(target[t]);
        }
        return matches;
    }

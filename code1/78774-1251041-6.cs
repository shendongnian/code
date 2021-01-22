    static List<string>[] FindMatches(string[] source, string[] target)
    {
        // Initialize array to hold results
        List<string>[] matches = new List<string>[source.Length];
        for (int i = 0; i < matches.Length; i++)
            matches[i] = new List<string>();
        int s = 0;
        for (int t = 0; t < target.Length; t++)
        {
            int m = CompareName(source[s], target[t]);
            if (m == 0)
            {
                matches[s].Add(target[t]);
            }
            else if (m > 0)
            {
                s++;
                if (s >= source.Length)
                    return matches;
                t--;
            }
        }
        return matches;
    }
    static int CompareName(string source, string target)
    {
        // Whatever comparison you need here, this one is really basic :)
        return target[0] - source[0];
    }

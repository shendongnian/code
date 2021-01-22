    // gets out a numerical value for each coordinate to make it easier to compare
    private long GetIndexForCoord(string coord)
    {
        Regex m_regex = new Regex("\\d\\d:\\d\\d:\\d\\d:\\d\\d");
        string cleaned = m_regex.Match(coord).Value;
        cleaned = cleaned.Replace(':', '0');
        return Convert.ToInt64(cleaned);
    }
    // gets out the 5 closest coordinates
    private List<string> GetResults(string coord)
    {
        long index = GetIndexForCoord(coord);
        // First find the 5 closest indexes to the one we're looking for
        List<long> found = new List<long>();
        while (found.Count < 5)
        {
                long closest = long.MaxValue;
                long closestAbs = long.MaxValue;
                foreach (long i in m_indexes)
                {
                    if (!found.Contains(i))
                    {
                        long absIndex = Math.Abs(index - i);
                        if (absIndex < closestAbs)
                        {
                            closest = i;
                            closestAbs = absIndex;
                        }
                    }
                }
                if (closest != long.MaxValue)
                {
                    found.Add(closest);
                }
        }
        // Then use those indexes to get the coordinates from the dictionary
        List<string> s = new List<string>();
        foreach (long i in found)
        {
            s.Add(m_dic[i]);
        }
        return s;
    }

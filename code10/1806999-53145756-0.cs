    static IEnumerable<(string Sector, char Separator)> Split(
        this string s,
        IEnumerable<char> separators,
        bool removeEmptyEntries)
    {
        var buffer = new StringBuilder();
        var separatorsSet = new HashSet<char>(separators);
        foreach (var c in s)
        {
            if (separatorsSet.Contains(c))
            {
                if (!removeEmptyEntries || buffer.Length > 0)
                    yield return (buffer.ToString(), c);
                buffer.Clear();
            }
            else
                buffer.Append(c);
        }
        if (buffer.Length > 0)
            yield return (buffer.ToString(), default(char));
    }

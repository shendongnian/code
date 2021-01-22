    static IDictionary<String, Int32> CountWords(IEnumerable<String> lines)
    {
        return lines
            .SelectMany(line => line.Split(' '))
            .GroupBy(word => word)
            .ToDictionary(group => group.Key, group => group.Count());
    }

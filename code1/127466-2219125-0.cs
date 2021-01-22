    public static bool CheckForEquality<T>(this IEnumerable<T> source, IEnumerable<T> destination)
    {
        if (source.Count() != destination.Count())
        {
            return false;
        }
        var dictionary = new Dictionary<T, int>();
        foreach (var value in source)
        {
            if (!dictionary.ContainsKey(value))
            {
                dictionary[value] = 1;
            }
            else
            {
                dictionary[value]++;
            }
        }
        foreach (var member in destination)
        {
            if (!dictionary.ContainsKey(member))
            {
                return false;
            }
            dictionary[member]--;
        }
        foreach (var kvp in dictionary)
        {
            if (kvp.Value != 0)
            {
                return false;
            }
        }
        return true;
    }

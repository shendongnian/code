    public static List<T> GetDistinctRandom<T>(this IList<T> source, int count)
    {
        if (count > source.Count)
            throw new ArgumentOutOfRangeException();
        if (count == source.Count)
            return new List<T>(source);
        var sourceDict = source.ToIndexedDictionary();
        if (count > source.Count / 2)
        {
            while (sourceDict.Count > count)
                sourceDict.Remove(source.GetRandomIndex());
            return sourceDict.Select(kvp => kvp.Value).ToList();
        }
        var randomDict = new Dictionary<int, T>(count);
        while (randomDict.Count < count)
        {
            int key = source.GetRandomIndex();
            if (!randomDict.ContainsKey(key))
                randomDict.Add(key, sourceDict[key]);
        }
        return randomDict.Select(kvp => kvp.Value).ToList();
    }

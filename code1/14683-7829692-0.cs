    public static int[] GetIndexes<T>(this T[]source, Func<T, bool> predicate)
    {
        List<int> matchingIndexes = new List<int>();
        for (int i = 0; i < source.Length; ++i) 
        {
            if (predicate(source[i]))
            {
                matchingIndexes.Add(i);
            }
        }
        return matchingIndexes.ToArray();
    }

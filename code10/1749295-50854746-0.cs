    public static IEnumerable<string[]> BatchedLinesFromFile(string filename, int batchSize)
    {
        string[] result = Enumerable.Repeat("", batchSize).ToArray();
        int count = 0;
        foreach (var line in File.ReadLines(filename))
        {
            result[count++] = line;
            if (count != batchSize)
                continue;
            yield return result;
            count  = 0;
            result = Enumerable.Repeat("", batchSize).ToArray();
        }
        if (count > 0)
            yield return result;
    }

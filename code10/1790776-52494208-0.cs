    private static IEnumerable<string> FindParts(byte[] file)
    {
        return file.Aggregate(new string[1], (acc, b) =>
        {
            if (b != 0)
            {
                acc[acc.Length - 1] += b.ToString("X2");
                return acc;
            }
            else
            {
                return acc.Concat(new string[1]).ToArray();
            }
        })
        .Where(s => !string.IsNullOrEmpty(s));
    }

    static IEnumerable<string> Split(string str, double chunkSize)
    {
        return Enumerable.Range(0, (int) Math.Ceiling(str.Length/chunkSize))
           .Select(i => new string(str
               .Skip(i * (int)chunkSize)
               .Take((int)chunkSize)
               .ToArray()));
    }

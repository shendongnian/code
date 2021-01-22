    static IEnumerable<string> Split(string str, double chunkSize)
    {
        double length = str.Length;
        var parts = (int) Math.Ceiling(str.Length/chunkSize);
        return Enumerable.Range(0, parts)
           .Select(i => new string(str
               .Skip(i * (int)chunkSize)
               .Take((int)chunkSize)
               .ToArray()));
    }

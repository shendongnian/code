    public static IEnumerable<string> SplitInChunks(string s, int size = 2)
    {
        return s.Select((c, i) => new {c, id = i / size})
            .GroupBy(x => x.id, x => x.c)
            .Select(g => new string(g.ToArray()));
    }

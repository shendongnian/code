    public static IEnumerable<IEnumerable<int>> GenerateCombinedPatterns
        (IEnumerable<IEnumerable<int>> patterns1,
         IEnumerable<IEnumerable<int>> patterns2)
    {
        var parallel1 = patterns1.AsParallel();
        return parallel1.SelectMany(p1 => patterns2.Select(p2 => p1.Concat(p2)))
            .Where(r => r.Sum() <= stockLen);
    }

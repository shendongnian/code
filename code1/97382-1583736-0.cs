    public static IEnumerable<int> Split(int n, int m)
    {
        Random r = new Random();
        int i = 0;
    
        var dict = Enumerable.Range(1, m - 1)
            .Select(x => new { Key = r.NextDouble(), Value = x })
            .OrderBy(x => x.Key)
            .Take(n - 2)
            .Select(x => x.Value)
            .Union(new[] { 0, m })
            .OrderBy(x => x)
            .ToDictionary(x => i++);
    
        return dict.Skip(1).Select(x => x.Value - dict[x.Key - 1]);
    }

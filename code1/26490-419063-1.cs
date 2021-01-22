    public static IList<IList<T>> Split<T>(IList<T> source)
    {
        return  source
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / 3)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }

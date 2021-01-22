    public static IEnumerable<int> Slice(this IEnumerable<int> enumerable, int size)
    {
        var list = new List<int>();
        foreach (var count in Enumerable.Range(0, size)) list.Add(enumerable.First());
        return list;
    }

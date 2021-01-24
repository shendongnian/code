    public static IEnumerable<Test> GetObjects(IEnumerable<Test> t, IEnumerable<int> ids)
    {
        var idHash = new HashSet<int>(ids);
        return t.Where(q => idHash.Contains(q.Id));
    }

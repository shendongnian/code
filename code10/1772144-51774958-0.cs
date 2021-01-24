    List<string> ids = new List<string>(new[] { "a", "b", "c", "d", "e", "f" });
    List<Object> objects = ids
        .AsParallel()
        .Select(id => getObject(id))
        .ToList();

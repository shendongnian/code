    var accessor = TypeAccessor.Create(type);
    List<object> results = new List<object>();
    foreach(var row in rows) {
        object obj = accessor.CreateNew();
        foreach(var col in cols) {
            accessor[obj, col.Name] = col.Value;
        }
        results.Add(obj);
    }

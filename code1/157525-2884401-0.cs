    var enumerator = HttpRuntime.Cache.GetEnumerator();
    Dictionary<string, object> cacheItems = new Dictionary<string, object>();
    while (enumerator.MoveNext())
        cacheItems.Add(enumerator.Key.ToString(), enumerator.Value);
    foreach (string key in cacheItems.Keys)
        HttpRuntime.Cache.Remove(key);

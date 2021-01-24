    public static IDictionary<string, string> GetHeaderValues(IReadOnlyList<string> keys, IHeaderDictionary headers)
    {
        return keys.Intersect(headers.Keys)
            .Select(k => new KeyValuePair<string,string>(k,headers[k]))
            .ToDictionary(p => p.Key, p => p.Value);
    }

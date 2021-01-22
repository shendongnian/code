    private static IEnumerable<KeyValuePair<string, string>> ParseQueryValues(object values)
    {
        // Check if a name/value collection.
        var nvc = values as NameValueCollection;
        if (nvc != null)
            return from key in nvc.AllKeys
                    let vals = nvc.GetValues(key)
                    from val in vals
                    select new KeyValuePair<string, string>(key, val);
        // Check if a string/string dictionary.
        var pairs = values as IEnumerable<KeyValuePair<string, string>>;
        if (pairs != null)
            return pairs;
        // Check if a string/object dictionary.
        pairs = (values as IEnumerable<KeyValuePair<string, object>>)?.Select(p =>
            new KeyValuePair<string, string>(p.Key, p.Value?.ToString()));
        if (pairs != null)
            return pairs;
        // Check if a non-generic dictionary.
        var dict = values as IDictionary;
        if (dict != null)
            pairs = dict.Cast<dynamic>().ToDictionary<dynamic, string, string>(
                p => p.Key.ToString(), p => p.Value?.ToString());
        if (pairs != null)
            return pairs;
        // Convert object properties to dictionary.
        return new RouteValueDictionary(values).Select(p =>
            new KeyValuePair<string, string>(p.Key, p.Value?.ToString()));
    }

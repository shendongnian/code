    private static IEnumerable<KeyValuePair<string, object>> ParseQuery(object values)
    {
        // Check if a name/value collection.
        var nvc = values as NameValueCollection;
        if (nvc != null)
            return from key in nvc.AllKeys
                   let vals = nvc.GetValues(key)
                   from val in vals
                   select new KeyValuePair<string, object>(key, val);
        // Check if an object/object dictionary.
        var pairs = values as IEnumerable<KeyValuePair<string, object>>;
        if (pairs != null)
            return pairs;
        // Check if a string/object dictionary.
        pairs = (values as IEnumerable<KeyValuePair<string, string>>)
            ?.Select(p => new KeyValuePair<string, object>(p.Key, p.Value));
        if (pairs != null)
            return pairs;
        // Check if a non-generic dictionary.
        var dict = values as IDictionary;
        if (dict != null)
            pairs = dict.Cast<dynamic>().ToDictionary<dynamic, string, object>(
                p => p.Key.ToString(), p => p.Value);
        if (pairs != null)
            return pairs;
        // Convert object properties to dictionary.
        return new RouteValueDictionary(values);
    }

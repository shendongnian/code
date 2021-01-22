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
        var ssd = values as IEnumerable<KeyValuePair<string, string>>;
        if (ssd != null)
            return ssd;
        // Check if a string/object dictionary.
        var sod = values as IEnumerable<KeyValuePair<string, object>>;
        if (sod == null)
        {
            // Check if a non-generic dictionary.
            var ngd = values as IDictionary;
            if (ngd != null)
                sod = ngd.Cast<dynamic>().ToDictionary<dynamic, string, object>(
                    p => p.Key.ToString(),
                    p => p.Value as object);
            // Convert object properties to dictionary.
            if (sod == null)
                sod = new RouteValueDictionary(values);
        }
        // Normalize and return the values.
        return from pair in sod
               from val in pair.Value as IEnumerable<string>
                 ?? new[] { pair.Value?.ToString() }
               select new KeyValuePair<string, string>(pair.Key, val);
    }

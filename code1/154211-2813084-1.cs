    var fooBar = foo.Keys
        .Union(bar.Keys)
        .Select(
            key => {
                int fval = 0, bval = 0;
                foo.TryGetValue(key, out fval);
                bar.TryGetValue(key, out bval);
                return new KeyValuePair<string, int>(key, fval + bval);
            }
        )
        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

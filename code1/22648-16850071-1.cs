    public static IEnumerable<T> Mode<T>(this IEnumerable<T> input)
    {            
        var dict = input.ToLookup(x => x);
        if (dict.Count == 0)
            return Enumerable.Empty<T>();
        var maxCount = dict.Max(x => x.Count());
        return dict.Where(x => x.Count() == maxCount).Select(x => x.Key);
    }
    var modes = { }.Mode().ToArray(); //returns { }
    var modes = { 1, 2, 3 }.Mode().ToArray(); //returns { 1, 2, 3 }
    var modes = { 1, 1, 2, 3 }.Mode().ToArray(); //returns { 1 }
    var modes = { 1, 2, 3, 1, 2 }.Mode().ToArray(); //returns { 1, 2 }

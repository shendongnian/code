    public static Func<TArgument, TResult> Memoize<TArgument, TResult>(this Func<TArgument, TResult> f)
    {
        Dictionary<TArgument, TResult> values;
        var methodDictionaries = new Dictionary<string, Dictionary<TArgument, TResult>>();
        var name = f.Method.Name;
        if (!methodDictionaries.TryGetValue(name, out values))
        {
            values = new Dictionary<TArgument, TResult>();
            methodDictionaries.Add(name, values);
        }
        
        return a =>
        {
            TResult value;
            if (!values.TryGetValue(a, out value))
            {
                value = f(a);
                values.Add(a, value);
            }
            return value;
        };
    }

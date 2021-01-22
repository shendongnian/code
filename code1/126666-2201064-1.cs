    static Func<A, R> Memoize(this Func<A, R> f)
    {
        // Return a function which is f with caching.
        var dictionary = new Dictionary<A, R>();
        return (A a)=>
        {
            R r;
            if(!dict.TryGetValue(a, out r))
            { // cache miss
                r = f(a);
                dict.Add(a, r);
            }
            return r;
        };
    }

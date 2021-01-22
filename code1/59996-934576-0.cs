    // I forget if you need this delegate definition -- this may be already defined in .NET 2.0
    public delegate R Func<T,R>(T obj);
    public static Dictionary<K,V> BuildDictionary<T,K,V>(IEnumerable<T> objs, Func<T,K> kf, Func<T,V> vf)
    {
        Dictionary<K,V> d = new Dictionary<K,V>();
        foreach (T obj in objs)
        {
            d[kf(obj)] = vf(obj);
        }
        return d;
    }
    Dictionary<string, string> fooDict = BuildDictionary(foos, new Func<Foo,string>(delegate(Foo foo) { return foo.Name; }), new Func<Foo,string>(delegate(Foo foo) { return foo.StreetAddress; }));

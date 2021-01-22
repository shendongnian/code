    static void Frob(IEnumerable ts)
    {
        foreach(object t in ts) Frob<object>(t);
    }
    static void Frob<T>(IEnumerable<T> ts)
    {
        foreach(T t in ts) Frob<T>(t);
    }
    static void Frob<T>(T t)
    {
        if (t is IEnumerable)
            Frob((IEnumerable) t);
        else
            // otherwise, frob a single T.
    }

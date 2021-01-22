    static void Frob(IEnumerable ts) // not generic!
    {
        foreach(object t in ts) Frob<object>(t);
    }
    static void Frob<T>(T t)
    {
        if (t is IEnumerable)
            Frob((IEnumerable) t);
        else
            // otherwise, frob a single T.
    }

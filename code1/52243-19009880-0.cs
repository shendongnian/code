    void Method(IEnumerable source)
    {
        var enumerator = source.GetEnumerator();
    
        if (enumerator.MoveNext())
        {
            Method2((dynamic)source);
        }
    }

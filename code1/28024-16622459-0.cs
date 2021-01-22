    public Foo Do()
    {
        return Do(_ => true);
    }
    public Foo Do(Func<T, bool> pattern)
    {
        return SomethingElse(pattern);
    }

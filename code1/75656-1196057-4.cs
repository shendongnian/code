    void Foo(string x, string y)
    {
        if (x == null)
        {
            throw new ArgumentNullException(nameof(x));
        }
        if (y == null)
        {
            throw new ArgumentNullException(nameof(y));
        }
        ...
    }

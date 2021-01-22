    void Foo(string x, string y)
    {
        if (x == null)
        {
            throw new ArgumentNullException("x");
        }
        if (y == null)
        {
            throw new ArgumentNullException("y");
        }
        ...
    }

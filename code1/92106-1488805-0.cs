    public void Foo(string x, string y, string z)
    {
        x.ThrowIfNull("x");
        y.ThrowIfNull("y");
        // Don't check z - it's allowed to be null
        // Method body here
    }

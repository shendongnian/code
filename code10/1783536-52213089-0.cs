    public void Example(string arg)
    {
        if (arg == null)
            throw new ArgumentNullException(nameof(arg));
        // …
    }

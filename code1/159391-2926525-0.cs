    public string Foo( string bar )
    {
        bar = bar ?? string.Empty;
        return bar.ToLower();
    }

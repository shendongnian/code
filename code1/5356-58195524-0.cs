    public static bool operator ==(Foo x, Foo y)
    {
        return x is null ? y is null : x.Equals(y);
    }
    
    public static bool operator !=(Foo x, Foo y)
    {
        return x is null ? y is null : !x.Equals(y);
    }

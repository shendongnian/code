    public string Serialize(object o)
    {
        if (!(o is T)) throw ...;
        return Serialize<T>(o);
    }
    public string Serialize<T>(T o)
    {
        // actual serialization code
    }

    public T this[string namedObject]
    {
        get { return (T)HttpContext.Current.Session[namedObject]; }
        set { HttpContext.Current.Session[namedObject] = Value; }
    }

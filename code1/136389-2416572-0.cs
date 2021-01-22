    public T this[string NamedObject]
    {
        get { return (T)HttpContext.Current.Session[NamedObject]; }
        set { HttpContext.Current.Session[NamedObject] = Value; }
    }

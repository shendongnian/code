    public T this[string name]
    {
        get { return (T)HttpContext.Current.Session[name]; }
        set { HttpContext.Current.Session[name] = Value; }
    }

    public object this[string key]
    {
        get { return ht[key]; }
        protected set { ht[key] = value; }
    }

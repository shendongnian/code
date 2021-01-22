    public Privilege this[int key]
    {
        get
        {
            return _privileges.Get(key, () => new Privilege());
        }
    }

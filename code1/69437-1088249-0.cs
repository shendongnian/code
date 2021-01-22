    public Privilege this[int key]
    {
        get
        {
            try { return _privileges[key]; }
            catch { return default(Privelege); }
        }
    }

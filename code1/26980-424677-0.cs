    public int this[int key]
    {
        get
        {
            return GetValue(key);
        }
        set
        {
            SetValue(key,value);
        }
    }

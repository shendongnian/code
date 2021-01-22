    public int PropertyA
    {
        get
        {
            return //etc...
        }
        set
        {
            if (condition == true)
            {
                throw new ArgumentOutOfRangeException("value", "/* etc... */");
            }
            // ... etc
        }
    }

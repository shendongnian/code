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
                throw new ArgumentOutOfRangeException(/* etc... */);
            }
            // ... etc
        }
    }

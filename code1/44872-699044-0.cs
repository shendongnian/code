    public SomeClass SomeProperty
    {
        get
        {
            lock (someLock)
            {
                return someField;
            }
        }
        set
        {
            lock (someLock)
            {
                someField = value;
            }
        }
    }

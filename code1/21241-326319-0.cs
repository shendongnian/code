    public List<Object> Objects
    {
        get
        {
            lock (container)
            {
                return this.container;
            }
        }
    }

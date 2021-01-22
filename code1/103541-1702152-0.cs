    public Object Clone()
    {
        return new TempClass
        {
            names = this.names.ToArray(),
            values = this.values.ToArray()
        };
    }

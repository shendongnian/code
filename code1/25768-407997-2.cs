    public override object this[string name]
    {
        get
        {
            return this.GetValue(this.GetOrdinal(name));
        }
    }
 

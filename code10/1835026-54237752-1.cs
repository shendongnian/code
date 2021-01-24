    public SecondObject[] Values { get; set; }
    IObject[] ICollection.Values
    {
        get
        {
            return this.Values;
        }
        set
        {
            this.Values = value?.Cast<SecondObject>().ToArray();
        }
    }

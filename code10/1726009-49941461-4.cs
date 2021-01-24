    [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
    public string Name
    {
        get { return (string)this["name"]; }
        set { this["name"] = value; }
    }

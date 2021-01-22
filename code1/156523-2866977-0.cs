    [ConfigurationProperty("level", IsKey = true, IsRequired = true)]
    private int LevelFromConfig
    {
        get { return (int)this["level"]; }
        set { this["level"] = value; }
    }
    
    public ProductLevel Level
    {
        get { return (ProductLevel)this.LevelFromConfig; }
    }

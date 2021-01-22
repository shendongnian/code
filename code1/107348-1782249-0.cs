    private string _CustomProperty;
    [Column(Storage="_CustomProperty", CanBeNull=true)]
    public string CustomProperty
    {
        get { return _CustomProperty; }
    }

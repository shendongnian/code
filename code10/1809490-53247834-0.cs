    [Column("Property1")]
    public string Property1Raw { get; set; }
    [IgnoreDataMember]
    public Guid? Property1
    {
        get => Guid.TryParse(Property1AsString, out Guid result) ? result : (Guid?)null;
        set => Property1Raw = value?.ToString();
    }

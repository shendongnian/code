    // Initialize to a string literal
    public string SomeProperty {get;set;} = "This is the default value";
    // Initialize with a simple expression
    public DateTime ConstructedAt {get;} = DateTime.Now;
    
    // Initialize with a conditional expression
    public bool IsFoo { get; } = SomeClass.SomeProperty ? true : false;

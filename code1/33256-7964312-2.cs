    [ImplementPropertyChanged]
    public double Radius { get; set; }
    
    [DependsOn("Radius")]
    public double Area 
    {
        get { return Radius * Radius * Math.PI; }
    }

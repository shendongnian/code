    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public FixedProperties FixedProps {get;set;}
    public string Name {
        get {return FixedProps.Name;}
        set {FixedProps.Name = value;}
    }

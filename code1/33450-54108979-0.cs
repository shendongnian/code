    enum Orientations
    {
        None, North, East, South, West
    }
    private Orientations? _orientation { get; set; }
    
    public Orientations Orientation
    {
        get
        {
            return _orientation ?? Orientations.None;
        }
        set
        {
            _orientation = value;
        }
    }

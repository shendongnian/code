    private string _Name = null;
    
    public string Name
    {
        get
        {
            return _Name;  // If you do return Name here - it will be overflow exception
        }
        set
        {
            _Name = value;  // If you do Name = value instead - it will be Overflow exception.
            NotifyPropertyChange("Name");
        }
    }

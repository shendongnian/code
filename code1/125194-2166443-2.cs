    public string Name
    {
        get { return _name; }
        set 
        {
           if (value = _name) return;
           _name = value;
           OnPropertyChange("Name");
        }
    }

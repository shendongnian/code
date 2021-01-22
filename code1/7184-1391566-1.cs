    private string _x;
    
    public string x { 
        get {return _x}; 
        set {
            if (Datetime.TryParse(value)) {
                _x = value;
            }
        }; 
    }

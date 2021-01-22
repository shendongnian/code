    private string _x;
    
    public string x { 
        get {return x}; 
        set {
            if (Datetime.TryParse(value)) {
                _x = value;
            }
        }; 
    }

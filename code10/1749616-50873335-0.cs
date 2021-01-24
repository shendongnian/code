    private string _myColor = "Red";
    
    public string MyColor
    {
        get { return _myColor; }
        set
        {
            _myColor = value;
            OnPropertyChanged("");
        }
    }

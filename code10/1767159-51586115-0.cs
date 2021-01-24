    bool _selectEnabled;
    public bool SelectEnabled
    {
        get => _selectEnabled;
        set
        { 
            SetProperty(ref _selectEnabled, value);
            myMethod("ABC", _selectEnabled); 
        }
    }

    private bool _isGroupEnabled;
    
    public bool IsGroupEnabled
    {
        get
        {
            return _isGroupEnabled;
        }
    
        set
        {
            _isGroupEnabled = value;
            this.OnPropertyChanged("IsGroupEnabled");
        }
    }

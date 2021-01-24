    private bool _IsMatch;
    public bool IsMatch 
    {
        get { return _IsMatch; }
        set 
        { 
             if (_IsMatch == value) return;
             _IsMatch = value;
             OnPropertyChanged("IsMatch");
        }
    }

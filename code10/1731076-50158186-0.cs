    bool _isLoaded;
    
    public bool IsLoaded
    {
        get { return _isLoaded; }
        set
        {
            _isLoaded = value;
            OnPropertyChanged(nameof(IsLoaded));
        }
    }
    
    protected void OnPropertyChanged (string name)
    {
        PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (name));
    }

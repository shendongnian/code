    private static event PropertyChangedEventHandler _propertyChanged;
    public PropertyChangedEventHandler PropertyChanged
    {
        get { return _propertyChanged; }
        set { _propertyChanged = value; }
    }

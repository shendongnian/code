    public event PropertyChangedEventHandler PropertyChanged;
    private object _Value;
    public object Value
    {
        get { return _value; }
        set
        {
            _value = value;
            // Call OnPropertyChanged whenever the property is updated
            OnPropertyChanged(value);
        }
    }
    protected void OnPropertyChanged(object val)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(val));
        }
    }

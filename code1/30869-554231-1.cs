    private string _firstName;
    public string FirstName
    {
        get { return _firstName; }
        set { SetNotifyingProperty("FirstName", ref _firstName, value); }
    }
    private void SetNotifyingProperty<T>(string propertyName,
                                         ref T field, T value)
    {
        if (value.Equals(field))
            return;
        field = value;
        OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    }

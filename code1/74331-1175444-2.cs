    public void FirePropertyChanged(string propertyName)
    {
        PropertyChangedEventArgs args2 = new PropertyChangedEventArgs(propertyName);
        OnPropertyChanged(this, args2);
    }

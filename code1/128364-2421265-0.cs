    protected void NotifyPropertyChanged(String propertyName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
    private void OnSourcePropertyChanged(Object sender, PropertyChangedEventArgs eventArgs)
    {
        if (eventArgs.PropertyName == "InterestingName")
        {
            // TODO:
        }
    }

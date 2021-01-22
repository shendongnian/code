    // INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    private void Set<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(property, value) == false)
        {
            property = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

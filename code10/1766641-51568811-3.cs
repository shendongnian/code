    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        if(PropertyChanged != null)
           PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

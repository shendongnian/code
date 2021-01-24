    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        var changedEvent = PropertyChanged;
        if(changedEvent != null)
           changedEvent.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

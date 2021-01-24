    public ObservableCollection<object> SelectedLocation
    {
        get { return _selectedLocation; }
        set
        {
            SetProperty(ref _selectedLocation, value);
        }
    }

    public StreetViewModel SelectedStreet
    {
        get { return _selectedStreet; }
        set
        {
            _selectedStreet = value.Clone() as StreetViewModel;
            CalculateAverage();
            _selectedStreet.HouseList.ListChanged += (o, e) => CalculateAverage();
            RaisePropertyChanged();
        }
    }

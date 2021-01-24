    private ObservableCollection<string> filteredLenses;
    public ObservableCollection<string> FilteredLenses
    {
        get
        {
            if (filteredLenses == null)
                filteredLenses = new ObservableCollection<string>();
            return filteredLenses;
        }
        set
        {
            filteredLenses = value;
            OnPropertyChanged("FilteredLenses");
        }
    }
    public string selectedValue;
    public string SelectedValue
    {
        get
        {
            return selectedValue;
        }
        set
        {
            if (value == "Okay")
            {
                // This logic can be done in many ways
                FilteredLenses.Clear();
                FilteredLenses.Add("Okay");
                OnPropertyChanged("FilteredLenses");
            }
            selectedValue = value;
            OnPropertyChanged("SelectedValue");
        }
    }

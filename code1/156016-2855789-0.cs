    private String _selectedItem;
    public String SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
            OnPropertyChanged(new PropertyChangedEventArgs("SelectedItem"));
        }
    }
    <ComboBox SelectedItem="{Binding SelectedItem}" />

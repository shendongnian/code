    private Item _selectedItem;
    public Item SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value; // TODO: Add extra code to trigger something because the user selected an item
            OnNotifyPropertyChanged();
        }
    }

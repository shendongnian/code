    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            _selectedIndex = value;
            if (_selectedIndex == 0)
                TextOne = string.Empty;
            else if (_selectedIndex == 1)
                TextTwo = string.Empty;
            NotifyPropertyChanged(nameof(SelectedIndex));
        }
    }

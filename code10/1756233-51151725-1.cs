    public event PropertyChangedEventHandler PropertyChanged;
    public Inventory SelectedInventory
    {
        get
        {
            return m_SelectedInventory;
        }
        set
        {
            m_SelectedInventory = value;
            RaisePropertyChanged(nameof(SelectedInventory));
        }
    }
    
    private void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

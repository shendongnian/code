    private List<Item> itemsList;
    public List<Item> ItemsList
    {
        get { return itemsList; }
        set
        {
            itemsList = value;
            NotifyPropertyChanged();
        }
    }
    private Item selectedItem;
    public Item SelectedItem
    {
        get { return selectedItem; }
        set
        {
            if (selectedItem != null)
                selectedIten.PropertyChanged -= OnItemPropertyChanged;
            selectedItem = value;
            NotifyPropertyChanged();
            if (selectedItem != null)
                selectedIten.PropertyChanged += OnItemPropertyChanged;
        }
    }
    private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        NotifyPropertyChanged("NoUnsavedChanges");
    }
    public bool NoUnsavedChanges
    {
        get { return !context.ChangeTracker.HasChanges(); }
    }
    public void SaveChanges()
    {
        context.SaveChanges();
        NotifyPropertyChanged("NoUnsavedChanges");
    }

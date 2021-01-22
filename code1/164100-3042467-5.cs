    private RangeObservableCollection<InventoryBTO> _inventoryRecords;
    public RangeObservableCollection<InventoryBTO> InventoryRecords
    {
        get { return _inventoryRecords; }
        set { _inventoryRecords = value; }
    }
    private InventoryBTO _selectedRecord;
    public InventoryBTO SelectedRecord
    {
        get { return _selectedRecord; }
        set 
        {
            if (_selectedRecord != value)
            {
                _selectedRecord = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SelectedRecord"));
            }
        }
    }
    public InventoryViewModel()
    {
        if (_inventoryRecords == null)
        {
            InventoryRecords = new ObservableCollection<InventoryBTO>();
            this.InventoryRecords.CollectionChanged += new NotifyCollectionChangedEventHandler(InventoryRecords_CollectionChanged);
        }
        this.InventoryRecords.AddRange(InventoryListBTO.GetAllInventoryRecords());
    }
    void InventoryRecords_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        //e.NewItems will be an IList of all the items that were added in the AddRange method...
    } 

    public ObservableCollection<InventoryBTO> InventoryRecords
    {
        get { return _inventoryRecords; }
        set 
        { 
          _inventoryRecords = value; 
          OnPropertyChanged(new PropertyChangedEventArgs("InventoryRecords"));
        }
     }

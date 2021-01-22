    public ObservableCollection<InventoryBTO> InventoryRecords
    {
        get { return _inventoryRecords; }
        set 
        { 
          _inventoryRecords = value; 
          onPropertyChanged(this, "InventoryRecords");
        }
     }

    public Device CellPhones{ get; set; }
    public ObservableCollection<DeviceItem> CellPhoneItems
    {
        get; set;
    }
    public Device Watches { get; set; }
    public ObservableCollection<DeviceItem> WatchItems
    {
        get; set;
    }
    public ObservableCollection<Device> Devices
    {
        get; set;
    }
    CellPhones = new Device("Cells");
    CellPhoneItems = new ObservableCollection<DeviceItem>();
    Watches = new Device("Watch");
    WatchItems = new ObservableCollection<DeviceItem>();
    CellPhones.Items = CellPhoneItems;
    Watches.Items = WatchItems;
    Devices = new ObservableCollection<Device>();
    Devices.Add(CellPhones);
    Devices.Add(Watches);

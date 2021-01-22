     private List<Device> _devices;
    public readonly System.Collections.ObjectModel.ReadOnlyCollection<Device> Devices 
    {
     get
     { 
    return (_devices.AsReadOnly());
     } 

    public class Device
    {
        public Device(String arg_DeviceName)
        {
            DeviceName = arg_DeviceName;
        }
        public String DeviceName { get; }
        public ObservableCollection<DeviceItem> Items
        {
            get; set;
        }
    }

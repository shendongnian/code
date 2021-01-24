    public partial class YourPage : ContentPage
        {
            public YourPage()
            {
                InitializeComponent();
                BindingContext = new YourViewModel();
            }
        }
    
        public void Refreshcmd()
    {
    //DeviceDiscovered is an event, when it discovers a device, we fire the eventhandler
        adapter.DeviceDiscovered += (s, a) =>
        {
            if (a.Device.Name != null)
            {
                (YourViewModel)Devices.Add(a.Device);               
                //DeviceName.Add(a.Device.Name);
            }
        };
        adapter.StartScanningForDevicesAsync();
    }

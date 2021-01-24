    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            User = new User_info("ZZZZ", "18", "5.8", "65kg");
            Phone = new Phone { DEVICE_NAME = "xxx", DEVICE_ID = "123456789" };
        }
        
        public User_info User { get; set; }
        public DeviceInfo Phone { get; set; }
        // If you need only the device's name in the view
        public string DeviceName => Phone.DEVICE_NAME;
    }

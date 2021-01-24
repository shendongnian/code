    namespace YourNameSpace.ViewModels
    {
        public class YourViewModel
        {
    
            private ObservableCollection<IDevice> devices;
            public ObservableCollection<IDevice> Devices
            {
                get { return devices; }
                set
                {
                    devices = value;
                }
            }
            public YourViewModel()
            {
                Devices = new ObservableCollection<IDevice>();
            }
        }
    }

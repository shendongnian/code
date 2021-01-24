    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public enum WM : uint
        {
            /// <summary>
            /// Notifies an application of a change to the hardware configuration of a device or the computer.
            /// </summary>
            DEVICECHANGE = 0x0219,
        }
        protected override void WndProc(ref Message m)
        {
            switch ((WM)m.Msg)
            {
                case WM.DEVICECHANGE:
                    var usbDevices = GetUSBDevices();
                    txtInfo.Text = string.Empty;
                    foreach (var usbDevice in usbDevices)
                    {
                        if (usbDevice.Name.Contains("Name of my usb device"))
                        {
                            // Code ..
                        }
                    }
                    break;
            }
            base.WndProc(ref m);
        }
        static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity where DeviceID Like ""USB%"""))
                collection = searcher.Get();
            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("Name"),
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }
            collection.Dispose();
            return devices;
        }
    }
    class USBDeviceInfo
    {
        public string Name { get; private set; }
        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }
        public USBDeviceInfo(string name, string deviceID, string pnpDeviceID, string description)
        {
            this.Name = name;
            this.DeviceID = deviceID;
            this.PnpDeviceID = pnpDeviceID;
            this.Description = description;
        }
    }

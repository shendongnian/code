        public void GetMonitorDetails()
        {
           using(ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DesktopMonitor")
           {
              foreach(ManagementObject currentObj in searcher.Get())
              {
                 String name = currentObj("Name").ToString();
                 String device_id = currentObj("DeviceID").ToString();
                 // ...
              }
           }
        }

    static List<USBDeviceInfo> GetUSBDevices()
    {
      List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
      ManagementObjectCollection collection;
      using (var searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_PnPEntity where DeviceID Like ""USB%"""))
        collection = searcher.Get();      
      foreach (var device in collection)
      {
        devices.Add(new USBDeviceInfo(
        (string)device.GetPropertyValue("DeviceID"),
        (string)device.GetPropertyValue("PNPDeviceID"),
        (string)device.GetPropertyValue("Description")
        ));
      }
      collection.Dispose();
      return devices;
    }

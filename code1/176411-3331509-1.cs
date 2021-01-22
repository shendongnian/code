    namespace ConsoleApplication1
    {
      using System;
      using System.Collections.Generic;
      using System.Management; // need to add System.Management to your project references.
      class Program
      {
        static void Main(string[] args)
        {
          var usbDevices = GetUSBDevices();
          foreach (var usbDevice in usbDevices)
          {
            Console.WriteLine("Device ID: {0}, PNP Device ID: {1}, Description: {2}",
                usbDevice.DeviceID, usbDevice.PnpDeviceID, usbDevice.Description);
          }
          Console.Read();
        }
        static List<USBDeviceInfo> GetUSBDevices()
        {
          List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
          ManagementObjectCollection collection;
          using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
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
      }
      class USBDeviceInfo
      {
        public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
        {
          this.DeviceID = deviceID;
          this.PnpDeviceID = pnpDeviceID;
          this.Description = description;
        }
        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }
      }
    }

    using System.Management;
    public class USBDeviceInfo
    {
        public string Availability { get; set; }
        public string Caption { get; set; }
        public string ClassCode { get; set; }
        public uint ConfigManagerErrorCode { get; set; }
        public bool ConfigManagerUserConfig { get; set; }
        public string CreationClassName { get; set; }
        public string CurrentAlternateSettings { get; set; }
        public string CurrentConfigValue { get; set; }
        public string Description { get; set; }
        public string DeviceID { get; set; }
        public string ErrorCleared { get; set; }
        public string ErrorDescription { get; set; }
        public string GangSwitched { get; set; }
        public string InstallDate { get; set; }
        public string LastErrorCode { get; set; }
        public string Name { get; set; }
        public string NumberOfConfigs { get; set; }
        public string NumberOfPorts { get; set; }
        public string PNPDeviceID { get; set; }
        public string PowerManagementCapabilities { get; set; }
        public string PowerManagementSupported { get; set; }
        public string ProtocolCode { get; set; }
        public string Status { get; set; }
        public string StatusInfo { get; set; }
        public string SubclassCode { get; set; }
        public string SystemCreationClassName { get; set; }
        public string SystemName { get; set; }
        public string USBVersion { get; set; }
    }
    public static List<USBDeviceInfo> GetUSBDevices()
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub");
        ManagementObjectCollection collection = searcher.Get();
        List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
        foreach (var device in collection)
        {
            USBDeviceInfo deviceInfo = new USBDeviceInfo();
            deviceInfo.Availability = (string)device.GetPropertyValue("Availability");
            deviceInfo.Caption = (string)device.GetPropertyValue("Caption");
            deviceInfo.ClassCode = (string)device.GetPropertyValue("ClassCode");
            deviceInfo.ConfigManagerErrorCode = (uint)device.GetPropertyValue("ConfigManagerErrorCode");
            deviceInfo.ConfigManagerUserConfig = (bool)device.GetPropertyValue("ConfigManagerUserConfig");
            deviceInfo.CreationClassName = (string)device.GetPropertyValue("CreationClassName");
            deviceInfo.CurrentAlternateSettings = (string)device.GetPropertyValue("CurrentAlternateSettings");
            deviceInfo.CurrentConfigValue = (string)device.GetPropertyValue("CurrentConfigValue");
            deviceInfo.Description = (string)device.GetPropertyValue("Description");
            deviceInfo.DeviceID = (string)device.GetPropertyValue("DeviceID");
            deviceInfo.ErrorCleared = (string)device.GetPropertyValue("ErrorCleared");
            deviceInfo.ErrorDescription = (string)device.GetPropertyValue("ErrorDescription");
            deviceInfo.GangSwitched = (string)device.GetPropertyValue("GangSwitched");
            deviceInfo.InstallDate = (string)device.GetPropertyValue("InstallDate");
            deviceInfo.LastErrorCode = (string)device.GetPropertyValue("LastErrorCode");
            deviceInfo.Name = (string)device.GetPropertyValue("Name");
            deviceInfo.NumberOfConfigs = (string)device.GetPropertyValue("NumberOfConfigs");
            deviceInfo.NumberOfPorts = (string)device.GetPropertyValue("NumberOfPorts");
            deviceInfo.PNPDeviceID = (string)device.GetPropertyValue("PNPDeviceID");
            deviceInfo.PowerManagementCapabilities = (string)device.GetPropertyValue("PowerManagementCapabilities");
            deviceInfo.PowerManagementSupported = (string)device.GetPropertyValue("PowerManagementSupported");
            deviceInfo.ProtocolCode = (string)device.GetPropertyValue("ProtocolCode");
            deviceInfo.Status = (string)device.GetPropertyValue("Status");
            deviceInfo.StatusInfo = (string)device.GetPropertyValue("StatusInfo");
            deviceInfo.SubclassCode = (string)device.GetPropertyValue("SubclassCode");
            deviceInfo.SystemCreationClassName = (string)device.GetPropertyValue("SystemCreationClassName");
            deviceInfo.SystemName = (string)device.GetPropertyValue("SystemName");
            deviceInfo.USBVersion = (string)device.GetPropertyValue("USBVersion");
            devices.Add(deviceInfo);
        }
        collection.Dispose();
        searcher.Dispose();
        return devices;
    }

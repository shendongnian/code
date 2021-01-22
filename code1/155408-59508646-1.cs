    public class SerialPortInfo
    {
        public SerialPortInfo(ManagementObject property)
        {
            this.Availability = property.GetPropertyValue("Availability") as int? ?? 0;
            this.Caption = property.GetPropertyValue("Caption") as string ?? string.Empty;
            this.ClassGuid = property.GetPropertyValue("ClassGuid") as string ?? string.Empty;
            this.CompatibleID = property.GetPropertyValue("CompatibleID") as string[] ?? new string[] {};
            this.ConfigManagerErrorCode = property.GetPropertyValue("ConfigManagerErrorCode") as int? ?? 0;
            this.ConfigManagerUserConfig = property.GetPropertyValue("ConfigManagerUserConfig") as bool? ?? false;
            this.CreationClassName = property.GetPropertyValue("CreationClassName") as string ?? string.Empty;
            this.Description = property.GetPropertyValue("Description") as string ?? string.Empty;
            this.DeviceID = property.GetPropertyValue("DeviceID") as string ?? string.Empty;
            this.ErrorCleared = property.GetPropertyValue("ErrorCleared") as bool? ?? false;
            this.ErrorDescription = property.GetPropertyValue("ErrorDescription") as string ?? string.Empty;
            this.HardwareID = property.GetPropertyValue("HardwareID") as string[] ?? new string[] { };
            this.InstallDate = property.GetPropertyValue("InstallDate") as DateTime? ?? DateTime.MinValue;
            this.LastErrorCode = property.GetPropertyValue("LastErrorCode") as int? ?? 0;
            this.Manufacturer = property.GetPropertyValue("Manufacturer") as string ?? string.Empty;
            this.Name = property.GetPropertyValue("Name") as string ?? string.Empty;
            this.PNPClass = property.GetPropertyValue("PNPClass") as string ?? string.Empty;
            this.PNPDeviceID = property.GetPropertyValue("PNPDeviceID") as string ?? string.Empty;
            this.PowerManagementCapabilities = property.GetPropertyValue("PowerManagementCapabilities") as int[] ?? new int[] { };
            this.PowerManagementSupported = property.GetPropertyValue("PowerManagementSupported") as bool? ?? false;
            this.Present = property.GetPropertyValue("Present") as bool? ?? false;
            this.Service = property.GetPropertyValue("Service") as string ?? string.Empty;
            this.Status = property.GetPropertyValue("Status") as string ?? string.Empty;
            this.StatusInfo = property.GetPropertyValue("StatusInfo") as int? ?? 0;
            this.SystemCreationClassName = property.GetPropertyValue("SystemCreationClassName") as string ?? string.Empty;
            this.SystemName = property.GetPropertyValue("SystemName") as string ?? string.Empty;
        }
        int Availability;
        string Caption;
        string ClassGuid;
        string[] CompatibleID;
        int ConfigManagerErrorCode;
        bool ConfigManagerUserConfig;
        string CreationClassName;
        string Description;
        string DeviceID;
        bool ErrorCleared;
        string ErrorDescription;
        string[] HardwareID;
        DateTime InstallDate;
        int LastErrorCode;
        string Manufacturer;
        string Name;
        string PNPClass;
        string PNPDeviceID;
        int[] PowerManagementCapabilities;
        bool PowerManagementSupported;
        bool Present;
        string Service;
        string Status;
        int StatusInfo;
        string SystemCreationClassName;
        string SystemName;       
    }

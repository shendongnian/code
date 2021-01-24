    List<object> items = new List<object>();
    DeviceSettings deviceSettings = new DeviceSettings();
    List<object> deviceNames = deviceSettings.GetMonitorFriendlyName();
    using (ManagementObjectCollection moc = searcher.Get())
    {
        var managementObjects = moc.Cast<ManagementObject>().ToArray();
        ConnectedMonitor_Number = managementObjects.Length;
        for (int i = 0; i < managementObjects.Length; i++)
        {
            object device = deviceNames[i];
            ManagementObject mo = managementObjects[i];
            Dictionary<string, object> item = new Dictionary<string, object>
            {
                { "DefaultMonitorLength", DefaultMonitor_Width },
                { "DefaultMonitorHeight", DefaultMonitor_Height },
                { "ConnectedMonitor_Numb", Convert.ToString(ConnectedMonitor_Number) },
                { "Caption", Convert.ToString(mo["Caption"]) },
                { "Name", Convert.ToString(mo["Name"]) },
                { "Description", Convert.ToString(mo["Description"]) },
                { "DeviceID", Convert.ToString(mo["DeviceID"]) },
                { "Manufacturer", Convert.ToString(mo["Manufacturer"]) },
                { "HardwareID", string.Join(";", (string[])mo["HardwareID"]) },
                { "Status", Convert.ToString(mo["Status"]) },
                { "monitorname", Convert.ToString(device["monitorname"])}
            };
            items.Add(item);
        }
    }

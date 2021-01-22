    string wmiPath = "Win32_Service.Name='" + SERVICE_NAME + "'";
    using (ManagementObject service = new ManagementObject(wmiPath))
    {
        object[] parameters = new object[11];
        parameters[5] = true;  // Enable desktop interaction
        service.InvokeMethod("Change", parameters);
    }

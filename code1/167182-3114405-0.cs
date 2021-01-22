    ManagementClass mgmt = new ManagementClass("Win32_Product");
    ManagementObjectCollection objCol = mgmt.GetInstances();
    foreach (ManagementObject obj in objCol)
    {
        Console.WriteLine("Product Name: {0}, Version: {1}.",
            obj.Properties["Name"].Value.ToString(),
            obj.Properties["Version"].Value.ToString());                    
    }

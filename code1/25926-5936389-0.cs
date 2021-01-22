    SelectQuery wmi_sorgusu = new SelectQuery("Select * from Win32_DiskDrive");
    ManagementObjectSearcher wmi_bulucu = new ManagementObjectSearcher( wmi_sorgusu );
    
    foreach (ManagementObject wmi_nesne in wmi_bulucu.Get()) {
        Console.WriteLine(wmi_nesne.GetPropertyValue( "DeviceID" ).ToString());
        Console.WriteLine(wmi_nesne.GetPropertyValue( "InterfaceType" ).ToString());
        Console.WriteLine(wmi_nesne.GetPropertyValue( "Caption" ).ToString());
        Console.WriteLine(wmi_nesne.GetPropertyValue( "Status" ).ToString());
        Console.WriteLine(wmi_nesne.GetPropertyValue( "MediaLoaded" ).ToString());
        //... etc
    }

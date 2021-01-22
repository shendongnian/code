    try
    {
        ManagementObjectSearcher searcher =
            new ManagementObjectSearcher("root\\WMI",
            "SELECT * FROM MSSerial_PortName");
    
        foreach (ManagementObject queryObj in searcher.Get())
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("MSSerial_PortName instance");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("InstanceName: {0}", queryObj["InstanceName"]);
    
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("MSSerial_PortName instance");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("PortName: {0}", queryObj["PortName"]);
    
            //If the serial port's instance name contains USB 
            //it must be a USB to serial device
            if (queryObj["InstanceName"].ToString().Contains("USB"))
            {
                Console.WriteLine(queryObj["PortName"] + " 
    			is a USB to SERIAL adapter/converter");
            }
        }
    }
    catch (ManagementException e)
    {
        Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
    } 

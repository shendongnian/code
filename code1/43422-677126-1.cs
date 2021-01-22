    using System.Management;
    
    ...
    
    string printerName = "YourPrinterName";
    string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printerName);
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
    ManagementObjectCollection coll = searcher.Get();
    
    foreach (ManagementObject printer in coll)
    {
        string portName = printer["PortName"].ToString();
        if(portName.StartsWith("IP_"))
        {
            Console.WriteLine(string.Format("Printer IP Address: {0}", portName.Substring(3)));
        }
    }

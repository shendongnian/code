    using System.Management;
...
    string printerName = "YourPrinterName";
    string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printerName);
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
    using (ManagementObjectCollection coll = searcher.Get())
    {
        try
        {
            foreach (ManagementObject printer in coll)
            {
                foreach (PropertyData property in printer.Properties)
                {
                    Console.WriteLine(string.Format("{0}: {1}", property.Name, property.Value));
                }
            }
        }
        catch (ManagementException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

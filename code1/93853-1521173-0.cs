    public static List<string> GetPrintersCollection()
    {
        if (printers == null)
        {
            printers = new List<string>();
            string searchQuery = "SELECT * FROM Win32_Printer";
            try
            {
                using (ManagementObjectSearcher searchPrinters = new ManagementObjectSearcher(searchQuery))
                {
                    ManagementObjectCollection Printers = searchPrinters.Get(); // <= Printers data below
                    foreach (ManagementObject printer in Printers)
                    {
                        printers.Add(printer.Properties["Name"].Value.ToString());
                    }
                }
            }
            catch (UnauthorizedAccessException err)
            {
                //Log & re-throw
                Console.WriteLine("Caught UnauthorizedAccessException:  " + err.ToString()); 
                throw;  //re-throw existing exception, not a new one
            }
            //there's no reason to catch the plain-old Exception 
        }
    
        return printers;
    }

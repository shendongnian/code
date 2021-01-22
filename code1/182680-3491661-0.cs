    try
            {
                ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher("root\\CIMV2", 
                    "SELECT * FROM Win32_DesktopMonitor"); 
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_DesktopMonitor instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Description: {0}", queryObj["Description"]);
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }

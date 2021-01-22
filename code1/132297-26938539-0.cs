            using System.Management;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Printer");
                foreach (ManagementObject obj in searcher.Get())
                {
                    if(obj != null)
                    {
                        if(obj["PrintProcessor"].ToString().ToUpper() != "WINPRINT")
                        {
                            Console.WriteLine(obj["Name"]);
                        }
                    }
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }

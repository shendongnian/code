    using System;
    using System.Management;
    using System.Windows.Forms;
    
    namespace WMISample
    {
        public class MyWMIQuery
        {
            public static void Main()
            {
                try
                {
                    ManagementObjectSearcher searcher = 
                        new ManagementObjectSearcher("root\\CIMV2", 
                        "SELECT * FROM Win32_Product"); 
    
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Win32_Product instance");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Name: {0}", queryObj["Name"]);
                        Console.WriteLine("Version: {0}", queryObj["Version"]);
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
            }
        }
    }

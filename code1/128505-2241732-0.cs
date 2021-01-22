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
                        "SELECT * FROM Win32_OperatingSystem"); 
    
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Win32_OperatingSystem instance");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("BuildNumber: {0}", queryObj["BuildNumber"]);
                        Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                        Console.WriteLine("OSArchitecture: {0}", queryObj["OSArchitecture"]);
                        Console.WriteLine("OSLanguage: {0}", queryObj["OSLanguage"]);
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

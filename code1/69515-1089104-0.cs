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
                        "SELECT * FROM Win32_UserAccount"); 
    
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Win32_UserAccount instance");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("AccountType: {0}", queryObj["AccountType"]);
                        Console.WriteLine("FullName: {0}", queryObj["FullName"]);
                        Console.WriteLine("Name: {0}", queryObj["Name"]);
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
            }
        }
    }

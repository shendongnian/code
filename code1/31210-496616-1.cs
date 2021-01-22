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
                    "SELECT * FROM Win32_DiskPartition"); 
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_DiskPartition instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Type: {0}", queryObj["Type"]);
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
        }
    }
}

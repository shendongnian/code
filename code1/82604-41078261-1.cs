        using System;
        using System.Management;
        using System.Windows.Forms;
        
        namespace MOS
        {
            public class ClassMOS
            {
                public static void Main()
                {
                    try
                    {
                        ManagementObjectSearcher searcher = 
                            new ManagementObjectSearcher("root\\CIMV2", 
                            "SELECT * FROM Win32_VideoController"); 
        
                        foreach (ManagementObject queryObj in searcher.Get())
                        {
                            Console.WriteLine("CurrentHorizontalResolution: {0}", queryObj["CurrentHorizontalResolution"]);
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("CurrentVerticalResolution: {0}", queryObj["CurrentVerticalResolution"]);
                        }
                    }
                    catch (ManagementException e)
                    {
                        MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                    }
                }
            }
    }

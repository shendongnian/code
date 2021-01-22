    using System.Management;
    using System.Windows.Forms;
    
     try
                {
                    ManagementObjectSearcher searcher = 
                        new ManagementObjectSearcher("root\\CIMV2", 
                        "SELECT * FROM Win32_Processor"); 
    
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Win32_Processor instance");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Architecture: {0}", queryObj["Architecture"]);
                        Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                        Console.WriteLine("Family: {0}", queryObj["Family"]);
                        Console.WriteLine("ProcessorId: {0}", queryObj["ProcessorId"]);
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }

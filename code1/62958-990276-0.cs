    using System;
    using System.Management;
    
    namespace WmiTest
    {
        class Program
        {
            static void Main()
            {
                EnumerationOptions options = new EnumerationOptions();
                options.Rewindable = false;
                options.ReturnImmediately = true;
    
                string query = "Select * From Win32_Process";
    
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher(@"root\cimv2", query, options);
    
                ManagementObjectCollection processes = searcher.Get();
    
                foreach (ManagementObject process in processes)
                {
                    Console.WriteLine(process["Name"]);
                }
    
                // Uncomment any of these
                // and you will get an exception:
    
                //Console.WriteLine(processes.Count);
                            
                /*
                foreach (ManagementObject process in processes)
                {
                    Console.WriteLine(process["Name"]);
                }
                */
            }
        }
    }

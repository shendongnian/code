    using System;
    using System.Diagnostics;
    using System.Management;
    
    namespace RamSystem
    {
        public class RamSystem
        {
            public static void GetRAM()
            {
                ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
                ManagementObjectCollection results = searcher.Get();
    
                double res;
    
                foreach (ManagementObject result in results)
                {
                    res = Convert.ToDouble(result["TotalVisibleMemorySize"]);
                    double fres = Math.Round((res / (1024 * 1024)), 2);
                    Console.WriteLine("Total usable memory size: " + fres + "GB");
                    Console.WriteLine("Total usable memory size: " + res + "KB");
                }
    
                Console.ReadLine();
            }
        }
    }

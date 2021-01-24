    using System;
    using System.Management;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //string deviceName = "TP-Link Wireless N PCI Express Adapter";
    
                ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\StandardCimv2");
    
                ObjectQuery query = new ObjectQuery($"SELECT * FROM MSFT_NetAdapter");// WHERE DriverDescription = \"{deviceName}\"");
               
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
    
                ManagementObjectCollection queryCollection = searcher.Get();
    
                foreach (ManagementObject m in queryCollection)
                {
                    Console.WriteLine($"{m["DriverDescription"]} : {m["FullDuplex"]}");
                }
    
                Console.ReadKey();
            }
        }
    }

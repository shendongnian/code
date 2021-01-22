    using System;
    using System.Management;
    
    namespace WMIGetMacAdr
    {
        class Program
        {
            static void Main(string[] args)
            {
                ManagementScope scope = new ManagementScope(@"\\localhost");  // TODO: remote computer (Windows WMI enabled computers only!)
                //scope.Options = new ConnectionOptions() { Username = ...  // use this to log on to another windows computer using a different l/p
                scope.Connect();
    
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration"); 
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
    
                foreach (ManagementObject obj in searcher.Get())
                {
                    string macadr = obj["MACAddress"] as string;
                    string[] ips = obj["IPAddress"] as string[];
                    if (ips != null)
                    {
                        foreach (var ip in ips)
                        {
                            Console.WriteLine("IP address {0} has MAC address {1}", ip, macadr );
                        }
                    }
                }
            }
        }
    }

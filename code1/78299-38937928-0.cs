    using System;
    using System.Management;
    namespace ConsoleAdapterEnabler
    {
        public static class NetworkAdapterEnabler
        {
            public static ManagementObjectSearcher GetWMINetworkAdapters(String filterExpression = "")
            {
                String queryString = "SELECT * FROM Win32_NetworkAdapter";
                if (filterExpression.Length > 0)
                {
                    queryString += String.Format(" WHERE Name LIKE '%{0}%' ", filterExpression);
                }
                WqlObjectQuery query = new WqlObjectQuery(queryString);
                ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher(query);
                return objectSearcher;
            }
    
            public static void EnableWMINetworkAdapters(String filterExpression = "")
            {
                foreach (ManagementObject adapter in GetWMINetworkAdapters(filterExpression).Get())
                {
                    //only enable if not already enabled
                    if (((bool)adapter.Properties["NetEnabled"].Value) != true)
                    {
                        adapter.InvokeMethod("Enable", null);
                    }
                }
            }
    
            public static void DisableWMINetworkAdapters(String filterExpression = "")
            {
                foreach (ManagementObject adapter in GetWMINetworkAdapters(filterExpression).Get())
                {
                    //If enabled, then disable
                    if (((bool)adapter.Properties["NetEnabled"].Value)==true)
                    {
                        adapter.InvokeMethod("Disable", null);
                    }
                }
            }
    
        }
        class Program
        {
            public static int Main(string[] args)
            {
                NetworkAdapterEnabler.DisableWMINetworkAdapters("Wireless");
    
                Console.WriteLine("Press any key to continue");
                var key = Console.ReadKey();
    
                NetworkAdapterEnabler.EnableWMINetworkAdapters("Wireless");
    
                Console.WriteLine("Press any key to continue");
                key = Console.ReadKey();
                return 0;
            }
        }
    }

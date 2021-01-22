    using System;
    using System.Management;
    class Query_SelectQuery
    {
        public static int Main(string[] args) 
        {
            SelectQuery selectQuery = new 
                SelectQuery("Select * from MSNdis_80211_WEPStatus where active=true");
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("root\wmi", selectQuery);
    
            foreach (ManagementObject disk in searcher.Get()) 
            {
                Console.WriteLine(disk.ToString());
            }
    
            Console.ReadLine();
            return 0;
        }
    }

    using System;
    using System.Management;
    class Query_SelectQuery
    {
        public static int Main(string[] args) 
        {
            SelectQuery selectQuery = new 
                SelectQuery("Win32_LogicalDisk");
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(selectQuery);
    
            foreach (ManagementObject disk in searcher.Get()) 
            {
                Console.WriteLine(disk.ToString());
            }
    
            Console.ReadLine();
            return 0;
        }
    }

    using System;
    using System.Linq;
    using System.Management;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var hdd = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE Index = '0'")
                .Get()
                .Cast<ManagementObject>()
                .First();
                Console.WriteLine(hdd["Model"].ToString());
    
                Console.Read();
                
            }
        }
    }

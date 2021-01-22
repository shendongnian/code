    using System;
    using System.Management;
    
    class Program
    {
        static void Main()
        {
            string query =
                @"Select * From Meta_Class Where __This Isa '__Event'";
    
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(query);
    
            foreach (ManagementBaseObject cimv2Class in searcher.Get())
            {
                Console.WriteLine(cimv2Class.ClassPath.ClassName);
            }
        }
    }

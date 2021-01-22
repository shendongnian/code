    using System;
    using System.Management;
    
    namespace WmiPlay
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    ManagementScope cimv2 = new ManagementScope(@"\\.\root\cimv2");
                    ManagementObject os = new ManagementObject(cimv2, new ManagementPath("Win32_OperatingSystem=@"), new ObjectGetOptions());
                    Console.Out.WriteLine(os);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            }
        }
    }

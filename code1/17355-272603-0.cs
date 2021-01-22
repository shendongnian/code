    using System;
    using System.Management;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                ManagementClass c = new ManagementClass("Win32_OperatingSystem");
    
                foreach (ManagementObject o in c.GetInstances())
                {
                    Console.WriteLine("Registered User: {0}, Organization: {1}", o["RegisteredUser"], o["Organization"]);
                }
                Console.WriteLine("Finis!");
                Console.ReadKey();
            }
        }
    }

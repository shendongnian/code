    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceProcess;
    using System.Management;
    
    namespace ServiceNames
    {
        class Program
        {
            static void Main(string[] args)
            {
                ServiceController[] services = ServiceController.GetServices();
    
                string serviceName = services[0].ServiceName;
                string objPath = string.Format("Win32_Service.Name='{0}'", serviceName);
                using (ManagementObject service = new ManagementObject(new ManagementPath(objPath)))
                {
                    Console.WriteLine(service["Description"]);
                }
    
                Console.Read();
            }
        }
    }

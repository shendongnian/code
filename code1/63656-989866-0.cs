    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceProcess;
    
    namespace ServiceNames
    {
        class Program
        {
            static void Main(string[] args)
            {
                ServiceController[] services = System.ServiceProcess.ServiceController.GetServices();
                foreach (ServiceController service in services)
                {
                    Console.WriteLine(service.DisplayName);
                }
                Console.Read();
            }
        }
    }

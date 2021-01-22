    namespace AtYourService
    {
        using System;
        using System.ServiceProcess;
    
        class Program
        {
            static void Main(string[] args)
            {
                ServiceController[] services = ServiceController.GetServices();
    
                foreach (ServiceController service in services)
                {
                    Console.WriteLine(
                        "The {0} service is currently {1}.",
                        service.DisplayName,
                        service.Status);
                }
    
                Console.Read();
            }
        }
    }

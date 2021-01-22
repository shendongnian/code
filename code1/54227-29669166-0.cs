    namespace ServiceName
    {
    using System;
    using System.ServiceProcess;
    class Service
    {
    public static bool IsServiceInstalled(string serviceName)
    {
  
     ServiceController[] services = ServiceController.GetServices();
  
     foreach (ServiceController service in services)
     {
       if (service.ServiceName == serviceName)
         return true;
     }
     return false;
       }
     }
     }

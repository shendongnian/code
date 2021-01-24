     ServiceController[] services = ServiceController.GetServices();
     foreach(ServiceController service in services)
     {
      If (service.ServiceName == "name here")
      { 
    Console.WriteLine(service.ServiceName+"=="+ service.Status);
     }}

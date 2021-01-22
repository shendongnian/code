    ServiceController[] services = ServiceController.GetServices();
    foreach(ServiceController service in services)
    {
        Console.WriteLine(service.ServiceName+"=="+ service.Status);
    }

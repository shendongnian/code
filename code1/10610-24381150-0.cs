    ServiceController[] services = ServiceController.GetServices();
    foreach(ServiceController service in services)
    {
        Console.WriteLine(service.Name+"=="+ service.Status);
    }

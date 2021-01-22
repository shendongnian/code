    static void Main()
    {
        Uri baseAddress = new Uri("http://localhost:8000/");
        WebServiceHost svcHost = new WebServiceHost(typeof(ServiceType));
        ServiceEndpoint svcEndpoint = svcHost.AddServiceEndpoint(typeof(IService),
          new WebHttpBinding(), baseAddress);
        svcEndpoint.Behaviors.Add(new WebHttpBehavior());
        svcHost.Open();
        Console.WriteLine("Press enter to quit...");
        Console.ReadLine();
        svcHost.Close();
    }

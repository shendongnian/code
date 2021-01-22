    Configuration config = ConfigurationManager.OpenExeConfiguration
                           (Assembly.GetExecutingAssembly().Location);
    ServicesSection section = config.GetSection("system.serviceModel/services") 
                                 as ServicesSection;
    foreach (ServiceElement svc in section.Services)
    {
       foreach (ServiceEndpointElement ep in svc.Endpoints)
       {
           if (ep.Name == "syncEndPoint")
           {
              ep.Address = new Uri("http://192.168.0.1:8000/whateverService");
           }
       }
    }
    config.Save(ConfigurationSaveMode.Full);

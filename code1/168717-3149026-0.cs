    using System.Configuration;
    using System.ServiceModel.Configuration;
    ClientSection clientSettings = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
    
    string address = null;
    foreach(ChannelEndpointElement endpoint in clientSettings.Endpoints)
    {
       if(endpoint.Name == "XXX")
       {
          address = endpoint.Address.ToString();
          break;
       }
    }

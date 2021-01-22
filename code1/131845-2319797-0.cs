    ClientSection cs = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
    if(cs != null)
    {
        foreach (ChannelEndpointElement ep in clientSection.Endpoints)
        {
            if(ep.Contract == 'IMyService')
            {
               Uri endpointAddress = e.Address;
            }
        }
    } 

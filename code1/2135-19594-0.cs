    // Automagically find all client endpoints defined in app.config
    ClientSection clientSection = 
        ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
    
    ChannelEndpointElementCollection endpointCollection =
        clientSection.ElementInformation.Properties[string.Empty].Value as     ChannelEndpointElementCollection;
    List<string> endpointNames = new List<string>();
    foreach (ChannelEndpointElement endpointElement in endpointCollection)
    {
        endpointNames.Add(endpointElement.Name);
    }
    // use endpointNames somehow ...

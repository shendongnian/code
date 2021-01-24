    using (var factory = new WebChannelFactory<IQueryParametersTestService>(new WebHttpBinding()))
    {
         factory.Endpoint.Address = new EndpointAddress(ServiceUri);
         factory.Endpoint.EndpointBehaviors.Add(new QueryParametersServiceBehavior());
         using (var client = factory.CreateWebChannel())
         {
               client.AddQueryParameter("format", "xml");
               client.AddQueryParameter("version", "2");
               var result = client.Channel.GetReport();
         }
    }

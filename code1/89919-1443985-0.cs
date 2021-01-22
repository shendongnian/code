    ServiceReference1.Service1Client oneService1Client = new ServiceReference1.Service1Client();
    oneService1Client.Endpoint.Address = new System.ServiceModel.EndpointAddress(
        new Uri(oneService1Client.Endpoint.Address.Uri.ToString().Replace("localhost", "127.0.0.1.")),
            oneService1Client.Endpoint.Address.Identity,
            oneService1Client.Endpoint.Address.Headers);

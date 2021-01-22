    private void CallTheService( string url )
    {
       TheService.TheServiceClient client = new TheService.TheServiceClient();
       client.Endpoint.Address = new System.ServiceModel.EndpointAddress(url);
       var results = client.AMethodFromTheService();
    }

    [WebMethod(Description = "My local service."]
    public RemoteService.ServiceResponse ServiceRequest(RemoteService.SendRequest myObject)
    {
           // Instance of remote service's method I'm 
           RemoteService.ServiceResponse SendResponse;
           ServiceProxyClient client = new ServiceProxyClient();    
           SendResponse = client.ServiceRequest(RemoteService.SendRequest)    
    
           return SendResponse;
      }

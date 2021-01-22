    try
    {
       var host = ServiceClientFactory.CreateInstance<MySericeClient>();
    
       ...... (use it).......
    
       host.Close();
    }
    catch(FaultException)
    {   
       host.Abort();
    }
    catch(CommunicationException)
    {
       host.Abort();
    }

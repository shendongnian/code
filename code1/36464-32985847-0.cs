    var client = new ProxyClient();
    try
    {
        ...
        client.Close();
    }
    finally
    {
        if(client.State != CommunicationState.Closed)
            client.Abort();
    }

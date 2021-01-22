    if (proxy.State == CommunicationState.Faulted)
    {
    	proxy.Abort();
    }
    else
    {
    	try
    	{
    		proxy.Close();
    	}
    	catch
    	{
    		proxy.Abort();
    	}
    }

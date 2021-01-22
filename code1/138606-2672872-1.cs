    using (WCFServiceClient client = new WCFServiceClient())
    {
        try
        {
            client.ThrowException();
            
        }
        catch (Exception ex)
        {
            // acknowledge the Faulted state and allow transition to Closed
            client.Abort();
    
            // handle the exception or rethrow, makes no nevermind to me, my
            // yob is done ;-D
        }
    } 

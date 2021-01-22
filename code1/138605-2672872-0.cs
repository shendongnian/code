    using (WCFServiceClient c = new WCFServiceClient())
    {
        try
        {
            c.HelloWorld();
        }
        catch (Exception ex)
        {
            // You don't know it yet but your mellow has just been harshed.
    
            // If you handle this exception and fall through you will still be cheerfully greeted with 
            // an unhandled CommunicationObjectFaultedException when 'using' tries to .Close() the client.
    
            // If you throw or re-throw from here you will never see that exception, it is gone forever. 
            // buh bye.
            // All you will get is an unhandled CommunicationObjectFaultedException
        }
    } // <-- here is where the CommunicationObjectFaultedException is thrown

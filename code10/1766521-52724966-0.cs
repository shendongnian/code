    // Stack with protocols we are going to try.
    Stack<SecurityProtocolType> protocolsToTry = new Stack<SecurityProtocolType>();
    protocolsToTry.Push(SecurityProtocolType.Tls);
    protocolsToTry.Push(SecurityProtocolType.Tls11);
    protocolsToTry.Push(SecurityProtocolType.Tls12);
    bool tryAgain = false;
    
    do
    {
       // Set the protocol we are going to try now.
       ServicePointManager.SecurityProtocol = protocolsToTry.Pop();
    
       try
       {
          // Tries to call the service using the current protocol.
          // If no exceptions are threw, we are ready to exit the loop.
          CallService();
          tryAgain = false;
       }
       catch (CommunicationException ex)
       {
          tryAgain = true;
       }
    } while(tryAgain && protocolsToTry.Count() > 0);

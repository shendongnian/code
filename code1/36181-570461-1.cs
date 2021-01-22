     int port = 456; //<--- This is your value
     bool isAvailable = true;
     // Evaluate current system tcp connections. This is the same information provided
     // by the netstat command line application, just in .Net strongly-typed object
     // form.  We will look through the list, and if our port we would like to use
     // in our TcpClient is occupied, we will set isAvailable to false.
     IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
     TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
    
     foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
     {
       if (tcpi.LocalEndPoint.Port==port)
       {
         isAvailable = false;
         break;
       }
     }
     // At this point, if isAvailable is true, we can proceed accordingly.

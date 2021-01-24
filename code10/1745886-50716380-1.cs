    public static string PingHost(string host)
    {
        //string to hold our return messge
        string returnMessage = string.Empty;
    
        //IPAddress instance for holding the returned host
        IPAddress address = GetIpFromHost(ref host);
    
        //set the ping options, TTL 128
        PingOptions pingOptions = new PingOptions(128, true);
    
        //create a new ping instance
        Ping ping = new Ping();
    
        //32 byte buffer (create empty)
        byte[] buffer = new byte[32];
    
        //set the ping options, TTL 128
        PingOptions pingOptions = new PingOptions(128, true);
    
        PingReply pingReply = ping.Send(address, 1000, buffer, pingOptions);
    
        if (!(pingReply == null))
        {
           switch (pingReply.Status)
           {
              case IPStatus.Success:
                    returnMessage = string.Format("Reply from {0}: bytes={1} time={2}ms TTL={3}", 
                                       pingReply.Address, 
                                       pingReply.Buffer.Length, 
                                       pingReply.RoundtripTime, 
                                       pingReply.Options.Ttl);
                    break;
              case IPStatus.TimedOut:
                    returnMessage = "Connection has timed out...";
                    break;
              default:
                    returnMessage = string.Format("Ping failed: {0}", pingReply.Status.ToString());
                    break;
           }
        }
        else
           returnMessage = "Connection failed for an unknown reason...";
    ...

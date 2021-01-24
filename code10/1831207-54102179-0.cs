    IPHostEntry host = default(IPHostEntry);
    
    try
    {
        host = Dns.GetHostEntry("localhost");
    
        try
        {
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected exception : {0}", e.ToString());
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Unexpected exception : {0} {1}", e.ToString(), host);
    }

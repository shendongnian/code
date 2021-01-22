    using System.Net.NetworkInformation;
    
    private static bool CanPing(string address)
    {
        Ping ping = new Ping();
    
        try
        {
            PingReply reply = ping.Send(address, 2000);
            if (reply == null) return false;
    
            return (reply.Status == IPStatus.Success);
        }
        catch (PingException e)
        {
            return false;
        }
    }

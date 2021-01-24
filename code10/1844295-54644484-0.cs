        using System.Net.NetworkInformation;
        var ping = new Ping();
        var reply = ping.Send("XX.XX.XX.XXX", 60 * 1000); // 1 minute time out (in ms)
        if (reply.Status == IPStatus.Success)
        {
            Response.Write("Server XX.XX.XX.XXX is up");
            RegisterUSer();
        }
        else
        {
            Response.Write("Server XX.XX.XX.XXX is down");
        }

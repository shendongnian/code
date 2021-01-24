    public IEnumerable<string> Get()
    {
        string ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();
        //https://en.wikipedia.org/wiki/Localhost
        //127.0.0.1    localhost
        //::1          localhost
        if (ip == "::1")
        {
            ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[2].ToString();
        }
        return new string[] { ip.ToString() };
     }

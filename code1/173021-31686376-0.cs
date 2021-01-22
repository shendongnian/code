    private bool getWanIp(ref string wanIP)
    {
        string routerResponse = sendRouterCommand("connection list");
        return (getWanIpFromRouterResponse(routerResponse, out wanIP));
    }
    private bool getWanIpFromRouterResponse(string routerResponse, out string ipResult)
    {
        ipResult = null;
        string[] responseLines = routerResponse.Split(new char[] { '\n' });
        //  RESP: 3947  17.110.226. 13:443       146.200.253. 16:60642     [R..A] Internet      6 tcp   128
        //<------------------  39  -------------><---  15   --->
        const int offset = 39, length = 15;
        foreach (string line in responseLines)
        {
            if (line.Length > (offset + length) && line.Contains("Internet"))
            {
                ipResult = line.Substring(39, 15).Replace(" ", "");
                return true;
            }
        }
        return false;
    }
                

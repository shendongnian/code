    public IPAddress GetExternalIP()
    {
        WebClient lol = new WebClient();
        string str = lol.DownloadString("http://www.ip-adress.com/");
        string pattern = "<h2>My IP address is: (.+)</h2>"
        MatchCollection matches1 = Regex.Matches(str, pattern);
        string ip = matches1(0).ToString;
        ip = ip.Remove(0, 21);
        ip = ip.Replace("
    
        ", "");
        ip = ip.Replace(" ", "");
        return IPAddress.Parse(ip);
    }

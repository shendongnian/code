    public static WebClient webclient = new WebClient();
    public static string GetIP()
    {
        string externalIP = "";
        externalIP = webclient.DownloadString("http://checkip.dyndns.org/");
        externalIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
                                       .Matches(externalIP)[0].ToString();
        return externalIP;
    }

    public static void Main(string[] args)
    {
        string externalip = new WebClient().DownloadString("http://icanhazip.com");    
        externalip = new System.Net.WebClient().DownloadString("http://bot.whatismyipaddress.com");
        externalip = new System.Net.WebClient().DownloadString("http://ipinfo.io/ip");
        Console.WriteLine(externalip);
    }

    public static void Main(string[] args)
    {
        string serverurl = "http://icanhazip.com";
        string externalip = new WebClient().DownloadString("http://icanhazip.com");            
        Console.WriteLine(externalip);
    }

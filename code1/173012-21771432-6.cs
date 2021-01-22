    public static void Main(string[] args)
    {
        string externalip = new WebClient().DownloadString("http://icanhazip.com");            
        Console.WriteLine(externalip);
    }

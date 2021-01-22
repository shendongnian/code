    public static IPAddress GetIPAddress(string hostName)
    {
        Ping ping = new Ping();
        var replay = ping.Send(hostName);
    
        if (replay.Status == IPStatus.Success)
        {
            return replay.Address;
        }
        return null;
     }
    public static void Main()
    {
        Console.WriteLine("Local IP Address: " + GetIPAddress(Dns.GetHostName()));
        Console.WriteLine("Google IP:" + GetIPAddress("google.com");
        Console.ReadLine();
    }

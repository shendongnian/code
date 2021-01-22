    public static void Main()
    {
    
        NetworkChange.NetworkAddressChanged += (s, e) =>
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var item in nics)
            {
                Console.WriteLine("Network Interface: {0}, Status: {1}", item.Name, item.OperationalStatus.ToString());
            }
        };
    
        string input = string.Empty;
        while (input != "quit")
        {
            input = Console.ReadLine();
        }
    }

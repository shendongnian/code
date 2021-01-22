    List<IPAddress> ipList = new List<IPAddress>();
    foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
    {
        foreach (var address in netInterface.GetIPProperties().UnicastAddresses)
        {
            if (address.Address.AddressFamily == AddressFamily.InterNetwork)
            {
                Console.WriteLine("found IP " + address.Address.ToString());
                ipList.Add(address.Address);
            }
        }
    }

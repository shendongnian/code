    var x = NetworkInterface.GetAllNetworkInterfaces()
        .Where(ni => ni.OperationalStatus == OperationalStatus.Up)
        .SelectMany(ni => ni.GetIPProperties().UnicastAddresses);
    // do something with the collection here to determine if you're on the right network.
    // just looping & printing here for example.
    foreach (var item in x)
    {        
        Console.WriteLine(item.Address);
    }

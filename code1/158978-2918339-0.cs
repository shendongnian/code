    var ep = _client.Client.RemoveEndPoint as IPEndPoint;
    if (ep != null)
    {
        Console.WriteLine("Address: {0}", ep.Address);
        Console.WriteLine("Port: {0}", ep.Port);
    }

    var ipsToCheck = new[] { "24.15.169.211", "69.198.255.121", "219.79.244.225" };
    while (true)
    {
        foreach (var ip in ipsToCheck)
        {
            using (var tcpClient = new TcpClient(AddressFamily.InterNetwork))
            {
                tcpClient.ReceiveTimeout = 5000;
                try
                {
                    tcpClient.Connect(IPAddress.Parse(ip), 8190);
                    using (var stream = tcpClient.GetStream())
                    {
                        var writer = new StreamWriter(stream);
                        var reader = new StreamReader(stream);
                        writer.Write("PLAYER_JOINED");
                        var buffer = new char[100];
                        reader.Read(buffer, 0, buffer.Length);
                        Console.WriteLine(buffer);
                        Console.WriteLine("{0}: Server Up", ip);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error connecting to {0}: {1}", ip, ex.Message);
                }
            }
        }
        Thread.Sleep(1000);
    }

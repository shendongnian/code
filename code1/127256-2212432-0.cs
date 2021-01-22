    using (var client = new TcpClient("127.0.0.1", 4000))
    using (var stream = client.GetStream())
    {
        using (var writer = new StreamWriter(stream))
        {
            // Write something to the socket
            writer.Write("HELLO");
        }
        using (var reader = new StreamReader(stream))
        {
            // Read the response until a \r\n
            string response = reader.ReadLine();
        }
    }

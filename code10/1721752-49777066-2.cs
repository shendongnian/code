       var server = new TcpListener(IPAddress.Loopback, port);            
        server.Start();
        while (true)
        {               
            var client = server.AcceptTcpClient();
            var stream = client.GetStream();
            using (var reader = new StreamReader(stream, Encoding.ASCII))
            using (var writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true })
            {
                var msg = reader.ReadLine();
                writer.WriteLine("[im an encrypted response]");
                msg = reader.ReadLine();
                writer.WriteLine("[im an encrypted response second bit]");
            }
        }

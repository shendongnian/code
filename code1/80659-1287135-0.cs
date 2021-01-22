    TcpListener recSock = new TcpListener(IPAddress.Loopback,  400);
    recSock.Start();
    using (TcpClient client = recSock.AcceptTcpClient())
    {
        using (NetworkStream netStream = client.GetStream())
        {
            Byte[] data = new Byte[256];
            int i;
            while ((i = netStream.Read(data, 0, data.Length)) != 0)
            {
                string cmd = Encoding.ASCII.GetString(data, 0, i);
                Console.WriteLine(cmd);
                if (cmd == "R")
                {
                    RestartScheduler();
                }
            }
        }
        client.Close();
    }

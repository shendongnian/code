        TcpListener recSock = new TcpListener(400);
        recSock.Start();
        while (!stopping)
        {
            TcpClient client = recSock.AcceptTcpClient();
            NetworkStream netStream = client.GetStream();
    
            Byte[] data = new Byte[256];
            int i = netStream.Read(data, 0, data.Length);
    
            while(i != 0) 
            {
                string cmd = ASCIIEncoding.ASCII.GetString(data, 0, i);
                Console.WriteLine(cmd);
                if(cmd == "R") {
                    RestartScheduler();
                }
                i = stream.Read(bytes, 0, bytes.Length);
            }
            Thread.Sleep(1); // Will allow the stopping bool to be updated
        }

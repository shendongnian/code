        TcpListener recSock = new TcpListener(400);
        recSock.Start();
        TcpClient client = recSock.AcceptTcpClient();
        NetworkStream netStream = client.GetStream();
    
        Byte[] data = new Byte[256];
    
        while(!stopping) 
        {
            int i = netStream.Read(data, 0, data.Length);
            string cmd = ASCIIEncoding.ASCII.GetString(data, 0, i);
            Console.WriteLine(cmd);
            if(cmd == "R") {
                RestartScheduler();
            }
            Thread.Sleep(1); // Will allow the stopping bool to be updated
        }

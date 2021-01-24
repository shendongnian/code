    IPAddress localAdd = IPAddress.Parse(SERVER_IP);
        TcpListener listener = new TcpListener(localAdd, PORT_NO);
        Console.WriteLine("Listening...");
        listener.Start();
        while (true)
        {
            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();
            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];
            //---read incoming stream---
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
            //---convert the data received into a string---
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received : " + dataReceived);
             //IF YOU WANT TO WRITE BACK TO CLIENT USE
           string yourmessage = console.ReadLine();
            Byte[] sendBytes = Encoding.ASCII.GetBytes(yourmessage);
            //---write back the text to the client---
            Console.WriteLine("Sending back : " + yourmessage );
            nwStream.Write(sendBytes, 0, sendBytes.Length);
            client.Close();
        }
        listener.Stop();

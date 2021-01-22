     StreamReader sr = new StreamReader("source.txt");
        
     TcpClient tcpClient = new TcpClient();
     tcpClient.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.15"), 5442));
     byte[] buffer = new byte[1500];
     long bytesSent = 0;
     while (bytesSent < sr.BaseStream.Length) {
            int bytesRead = sr.BaseStream.Read(buffer, 0, 1500);
            tcpClient.GetStream().Write(buffer, 0, bytesRead);
            Console.WriteLine(bytesRead + " bytes sent.");
            bytesSent += bytesRead;
      }
      tcpClient.Close();
      Console.WriteLine("finished");
      Console.ReadLine();

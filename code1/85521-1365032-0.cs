IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
TcpListener listener = new TcpListener(ep);
listener.Start();
TcpClient client = listener.AcceptTcpClient();
NetworkStream s = client.GetStream();
byte[] buffer = new byte[32];
Console.WriteLine(s.Read(buffer, 0, 32));
Console.WriteLine("Press any key to continue...");
Console.Read();

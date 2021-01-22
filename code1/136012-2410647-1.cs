    public static void Main(string[] args)
    {
      IPEndPoint remoteEp = null;
      UdpClient client = new UdpClient(4242);
      client.Client.ReceiveBufferSize = 4096;
      Console.Write("Start sending data...");
      client.Receive(ref remoteEp);
      Console.WriteLine("Good");
      Thread.Sleep(5000);
      Console.WriteLine("Stop sending data!");
      Thread.Sleep(1500);
      int count = 0;
      while (true)
      {
        client.Receive(ref remoteEp);
        Console.WriteLine(string.Format("Count: {0}", ++count));
      }
    }

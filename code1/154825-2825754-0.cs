    using System.Net.NetworkInformation;
    Ping sender = new Ping();
    PingReply reply = sender.Send ("www.example.com");
    if (reply.Status == IPStatus.Success)
    {
      Console.WriteLine("Ping successful.");
    }
 

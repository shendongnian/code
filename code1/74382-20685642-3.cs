     NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
     foreach (var adapter in adapters)
     {
          // Is Up, Down, something else?
          Console.WriteLine("   {0} is {1}", adapter.Name, dapter.OperationalStatus);
          var stats = adapter.GetIPStatistics();
          // Read some properties
          Console.WriteLine("       Bytes Recieved: {0}", stats.BytesReceived);
          Console.WriteLine("       Bytes Sent: {0}", stats.BytesSent);
     }

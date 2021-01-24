      TelemetryClient client = new TelemetryClient();
      TelemetryConfiguration.Active.InstrumentationKey = "your key";  
      client.GetMetric("test33").TrackValue(100);  
        
      System.Threading.Thread.Sleep(1000*5);
      client.Flush();
    
      Console.WriteLine("Hello World!");
      Console.ReadLine();

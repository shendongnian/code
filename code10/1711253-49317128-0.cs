    ChannelFactory<IServer> factory = new ChannelFactory<IServer>("defaultEndPoint");
    // !!! IServer channel = factory.CreateChannel();
    
    const int threadCount = 6;
    int value = 0;
    for (int i = 0; i < threadCount; i++)
    {
      new Thread(state =>
        {
          int n;
          lock (lockObj)
          {
            value++;
            n = value;
          }
          IServer channel = factory.CreateChannel(); // !!! 
          Console.WriteLine("Send value = {0}, Time = {1}", n, DateTime.Now.TimeOfDay);
          n = channel.GetResult(n);
          Console.WriteLine("                                          Response value = {0}, Time = {1}", n, DateTime.Now.TimeOfDay);
        }).Start();
    }

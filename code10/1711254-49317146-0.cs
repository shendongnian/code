        ChannelFactory<IServer> factory = new ChannelFactory<IServer>();
        const int threadCount = 6;
        int value = 0; 
        for (int i = 0; i < threadCount; i++)
        {
          new Thread(state =>
          {
            IServer channel = factory.CreateChannel();
            int n;
            lock (lockObj)
            {
                value++;
                n = value;
            }
            ...

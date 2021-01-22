      // Create a channel factory.
      NetTcpBinding b = new NetTcpBinding();
      b.Security.Mode = SecurityMode.None;
      Uri tcpUri = new Uri("net.tcp://localhost:8008/Calculator");
      ChannelFactory<ICalculator> myChannelFactory = new ChannelFactory<ICalculator>(b,new EndpointAddress(tcpUri));
      // Create a channel.
      ICalculator calculator = myChannelFactory.CreateChannel();

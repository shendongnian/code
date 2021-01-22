            TcpClientChannel channel = new TcpClientChannel();
            ChannelServices.RegisterChannel(channel, true);
            RemoteObject remoteObject = (RemoteObject)Activator.GetObject(
                typeof(RemoteObject), "tcp://localhost:9090/RemoteObject.rem");
            Console.WriteLine(remoteObject.Server.SomethingMore);

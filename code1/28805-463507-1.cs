    class ServiceConsoleHandler
    {
         …
         TcpServerChannel channel = new TcpServerChannel(9090);
         ChannelServices.RegisterChannel(channel, true);
         RemoteObject remoteObject = new RemoteObject();
         remoteObject.Server = this;
         RemotingServices.Marshal(remoteObject, "RemoteObject.rem");
         …
    }

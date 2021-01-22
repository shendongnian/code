    public static TcpState GetState(this TcpClient tcpClient)
    {
      var foo = IPGlobalProperties.GetIPGlobalProperties()
        .GetActiveTcpConnections()
        .SingleOrDefault(x => x.LocalEndPoint.Equals(tcpClient.Client.LocalEndPoint));
      return foo != null ? foo.State : TcpState.Unknown;
    }

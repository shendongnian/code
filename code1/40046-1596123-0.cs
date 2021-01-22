    public static bool ValidateUser(
        string userName, 
        string domain, 
        string password)
    {
        var tcpListener = new TcpListener(IPAddress.Loopback, 0);
        tcpListener.Start();
        var isLoggedOn = false;
        tcpListener.BeginAcceptTcpClient(
            delegate(IAsyncResult asyncResult)
            {
                using (var serverSide = 
                    new NegotiateStream(
                         tcpListener.EndAcceptTcpClient(
                            asyncResult).GetStream()))
                {
                    try
                    {
                    serverSide.AuthenticateAsServer(
                        CredentialCache.DefaultNetworkCredentials,
                        ProtectionLevel.None, 
                        TokenImpersonationLevel.Impersonation);
                    var id = (WindowsIdentity)serverSide.RemoteIdentity;
                    isLoggedOn = id != null;
                    }
                    catch (InvalidCredentialException) { }
                }
            }, null);
        var ipEndpoint = (IPEndPoint) tcpListener.LocalEndpoint;
        using (var clientSide = 
            new NegotiateStream(
                new TcpClient(
                    ipEndpoint.Address.ToString(),
                    ipEndpoint.Port).GetStream()))
        {
            try
            {
                clientSide.AuthenticateAsClient(
                    new NetworkCredential(
                        userName,
                        password,
                        domain),
                    "",
                    ProtectionLevel.None,
                    TokenImpersonationLevel.Impersonation);
            }
            catch(InvalidCredentialException){}
        }
        tcpListener.Stop();
        return isLoggedOn;
    }

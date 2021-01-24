    client = new SvnClient();
    client.Authentication.ForceCredentials(login, password);
    client.Authentication.SslServerTrustHandlers += delegate (object sender, SharpSvn.Security.SvnSslServerTrustEventArgs e)
     {
       e.AcceptedFailures = e.Failures;
       e.Save = true;
     };

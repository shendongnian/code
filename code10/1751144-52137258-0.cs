    //getting the cert
    var certificate = new X509Certificate2(@"[PATH_TO_CERT]", "[PASSWORD]");
    //creating client's Ssl Stream
    var clientStream = new SslStream(client, false);
    await clientStream.AuthenticateAsServerAsync(certificate, false, SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Ssl3, false);
                

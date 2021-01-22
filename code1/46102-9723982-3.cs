    TcpClient client = new TcpClient(machineName,443);
    Console.WriteLine("Client connected.");
    // Create an SSL stream, specifying the callback above.
    SslStream sslStream = new SslStream(
        client.GetStream(), 
        false, 
        new RemoteCertificateValidationCallback (ValidateRemoteCertificate), 
        null
        );

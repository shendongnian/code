    public void Send(string server, string from, string to)
    {
        // Client to Exchange server
        SmtpClient client = new SmtpClient(server);
        // Message
        MailMessage message = new MailMessage(from, to);
        message.Body = "This is a test e-mail message sent by an application. ";
        message.Subject = "test message 1";
        // Credentials are necessary if the server requires the client 
        // to authenticate before it will send e-mail on the client's behalf.
        client.Credentials = CredentialCache.DefaultNetworkCredentials;
        
        // Send
        client.Send(message);
    }

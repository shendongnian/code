    using System.Net.Mail;
    
     
    // the e-mail details
    String from = "me@server.com";
    String to   = "someone@server.com";;
    
    // build up the message
    MailMessage message = new MailMessage(from, to);
    message.Subject = "My Title";
    message.Body += "This is the biody of my message";
    
    // create a server pointing to your mail server
    String server = "mail.server.com";
       
    // create a client
    SmtpClient client = new SmtpClient(server);
    client.Credentials = CredentialCache.DefaultNetworkCredentials;
    
    // send the message
    client.Send(message);

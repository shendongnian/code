    using EASendMail;
    string login = @"login";
    string password = @"password";
    
    SmtpMail oMail = new SmtpMail("TryIt");
    SmtpClient oSmtp = new SmtpClient();
    oMail.From = "from@email.com";
    oMail.To = "to@email.com";
    oMail.AddAttachment(fileName, fileByteArray);
    oMail.Subject = "Subject";
    oMail.HtmlBody = "HTMLBody";
    SmtpServer oServer = new SmtpServer("mail.email.com");
    oServer.Protocol = ServerProtocol.ExchangeEWS;
    oServer.User = login;
    oServer.Password = password;
    oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
    try
    {
        Console.WriteLine("start to send email ...");
        oSmtp.SendMail(oServer, oMail);
        Console.WriteLine("email was sent successfully!");
    }
    catch (Exception ep)
    {
        Console.WriteLine("failed to send email with the following error:");
        Console.WriteLine(ep.Message);
    }

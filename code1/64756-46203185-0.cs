    using MailKit.Net.Smtp;
    using MimeKit;
    var client = new SmtpClient();
    client.Connect("server.name", 465, true);
    // Note: since we don't have an OAuth2 token, disable the XOAUTH2 authentication mechanism.
    client.AuthenticationMechanisms.Remove ("XOAUTH2");
    
    if (needsUserAndPwd)
    {
    	// Note: only needed if the SMTP server requires authentication
    	client.Authenticate (user, pwd);
    }
    
    var msg = new MimeMessage();
    msg.From.Add(new MailboxAddress("sender@ema.il"));
    msg.To  .Add(new MailboxAddress("target@ema.il"));
    msg.Subject = "This is a test subject";
    
    msg.Body = new TextPart("plain") {
    	Text = "This is a sample message body"
    };
    
    client.Send(msg);
    client.Disconnect(true);

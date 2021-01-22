    string Sender     = "somebody@somewhere.com";
    
    string Username   = "username";
    string Password   = "********";
    
    string Recipient  = "somebody@somewhere.com";
    
    string Subject    = "Enter subject here.";
    string Message    = "Enter message here.";
    
    string Host       = "mail.server.com";
    int Port          = 25;
    
    MailMessage Mail = new MailMessage(Sender, Recipient);
    Mail.Subject     = Subject;
    Mail.Body        = Message;
    
    SmtpClient SmtpMail    = new SmtpClient(Host, Port);
    SmtpMail.EnableSsl     = true;
    SmtpMail.Credentials   = new System.Net.NetworkCredential(Username, Password);
    
    SmtpMail.Send(Mail);
    
    Mail.Dispose();

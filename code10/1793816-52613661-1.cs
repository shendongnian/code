    MailMessage mail = new MailMessage();
    SmtpClient SmtpServer = new SmtpClient();
    List<string> To = new List<string>();
    To.Add("email1@gmail.com");
    To.Add("email1@gmail.com");
    
    foreach (var item in To)
    {
         mail.To.Add(to);
    }
    SmtpServer.Send(mail);

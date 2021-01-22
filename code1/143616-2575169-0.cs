    private void SendMail(string from, string body) 
    { 
        string mailServerName = "plus.smtp.mail.yahoo.com"; 
        int mailServerPort = 465;
        string toAddress = "aditya15417@yahoo.com";
        string subject = "feedback";
        string username = "user";
        string password = "password";
        SmtpClient mailClient = new SmtpClient(mailServerName, 
                                               mailServerPort); 
        mailClient.Host = mailServerName; 
        mailClient.Credentials = new NetworkCredential(username, 
                                                       password);
        mailClient.EnableSsl = true;
        using (MailMessage message = new MailMessage(from, 
                                                     toAddress, 
                                                     subject, 
                                                     body))
            mailClient.Send(message); 
    } 

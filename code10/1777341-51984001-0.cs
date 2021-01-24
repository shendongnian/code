    public static void SendEMail(string to, string subject, string body)
    {
        SmtpClient smtpClient = new SmtpClient("smtp.mail.yahoo.com", 587);
    
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
    
        smtpClient.Credentials = new NetworkCredential("my@com.pl", "12345!");
    
        MailMessage mailMessage = new MailMessage("\"" + Info.SiteName + "\" <" + Info.EMail + ">", "recipient1@gmail.com");
    
        mailMessage.Bcc.Add("recipient2@gmail.com");
        mailMessage.Bcc.Add("recipient3@gmail.com");
        mailMessage.Bcc.Add("recipient4@gmail.com");
        mailMessage.Bcc.Add("recipient5@gmail.com");
        mailMessage.Bcc.Add("recipient6@gmail.com");
    
        mailMessage.IsBodyHtml = true;
    
        mailMessage.Priority = MailPriority.High;
    
        mailMessage.Body = body;
        mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
        mailMessage.Subject = subject;
        mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
    
        smtpClient.Send(mailMessage);
    }

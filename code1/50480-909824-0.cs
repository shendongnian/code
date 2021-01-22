    #using System.Net.Mail;
    
    SmtpClient smtpClient = new SmtpClient(host, port);
    MailMessage message = new MailMessage(from, to, subject, body);
    Attachment attachment = new Attachment(@"H:\attachment.jpg");
    message.Attachments.Add(attachment);
            
    System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(username, password);
    smtpClient.UseDefaultCredentials = false;
    smtpClient.Credentials = SMTPUserInfo;
    smtpClient.Send(message);

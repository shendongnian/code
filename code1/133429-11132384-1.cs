    using System.Net;
    using System.Net.Mail;
    public void email_send()
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("your mail@gmail.com");
        mail.To.Add("to_mail@gmail.com");
        mail.Subject = "Test Mail - 1";
        mail.Body = "mail with attachment";
    
        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
        mail.Attachments.Add(attachment);
    
        SmtpServer.Port = 587;
        SmtpServer.Credentials = new System.Net.NetworkCredential("your mail@gmail.com", "your password");
        SmtpServer.EnableSsl = true;
    
        SmtpServer.Send(mail);
    }

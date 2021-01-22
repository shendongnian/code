    using System.Net;
    using System.Net.Mail;
     
    public void email_send()
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("from@gmail.com");
        mail.To.Add("to@gmail.com");
        mail.Subject = "Your Subject";
        mail.Body = "Body Content goes here";
     
        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment("c:/file.txt");
        mail.Attachments.Add(attachment);
     
        SmtpServer.Port = 587;
        SmtpServer.Credentials = new System.Net.NetworkCredential("from@gmail.com", "mailpassword");
        SmtpServer.EnableSsl = true;
        SmtpServer.Send(mail);
     
    }

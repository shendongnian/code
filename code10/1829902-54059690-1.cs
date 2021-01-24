    string smtpAddress = "smtp.gmail.com";
    int portNumber = 587;
    bool enableSSL = true;
    /// This mail from can just be a display only mail I'd 
    string emailFrom = "no-reply@gmail.com";
    
    string subject = "your subject";
    string body = createEmailBody();
    using (MailMessage mail = new MailMessage())
    {
    mail.From = new MailAddress(emailFrom);
    mail.To.Add(emailTo);
    /// Add more to IDs if you want to send it to multiple people.
    mail.Subject = subject;
    mail.Body = body;
    mail.IsBodyHtml = true;
    // This is required to keep formatting of your html contemts
    /// Add attachments if you want, this is optional
    mail.Attachments.Add(new Attachment(yourfilepath));
  
       using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
        {
        smtp.Credentials = new NetworkCredential(your-smtp-account-email, your-smtp-account-password);
        smtp.EnableSsl = enableSSL;
        smtp.Send(mail);
        }
    }

    var message = new MailMessage(FromEmailAdress, ToEmailAdress);
    message.Subject = subject;
    message.Body = message;
    
    using (SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587))
    {
        mailer.Credentials = new NetworkCredential(FromEmailAdress, password);
        mailer.EnableSsl = true;
        mailer.Send(message);
    }

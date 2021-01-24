    MailMessage mailMessage = new MailMessage();
    mailMessage.From = new MailAddress("info@*****.com");
    mailMessage.To.Add("info@*****.com");
    mailMessage.Body = "body";
    mailMessage.Subject = "subject";
    client.Send(mailMessage);

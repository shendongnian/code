    MailMessage message = new MailMessage();
    message.From = new MailAddress("from@email.com", "from name");
    message.Subject = "Email Subject";
    message.Body = body;
    message.BodyEncoding = Encoding.ASCII;
    message.IsBodyHtml = IsHtml;
    SmtpClient smtp = new SmtpClient("server");
    smtp.Send(m);

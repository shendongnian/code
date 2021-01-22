    var message = new MailMessage(Email, mailTo);
    message.IsBodyHtml = true;
    message.SubjectEncoding = message.BodyEncoding = Encoding.UTF8;
    message.Subject = "Subject";
    message.Body = msgBody;
    smtpclient.Send(message);

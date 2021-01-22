    SmtpClient smtpClient = new SmtpClient(smtpServer);
    smtpClient.ServicePoint.ConnectionLeaseTimeout = 0;
    for (int i = 0; i < number; i++)
    {
        MailAddress to = new MailAddress(iMail.to);
        MailAddress from = new MailAddress(iMail.from, iMail.displayName);
        string body = iMail.body;
        string subject = iMail.sub;
        using (MailMessage mailMessage = new MailMessage(from, to))
        {
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Sender = from;
            smtpClient.Send(mailMessage);
        }
    }

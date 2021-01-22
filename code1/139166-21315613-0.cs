     MailMessage mailMessage = new MailMessage(smtpUser, toAddress);
     if (!string.IsNullOrEmpty(cc))
     {
        mailMessage.CC.Add(cc);
     }
     if (!string.IsNullOrEmpty(bcc))
     {
        mailMessage.Bcc.Add(bcc);
     }

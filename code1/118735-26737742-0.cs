     SmtpClient smtpClient = InitSMTPClient();
     using (smtpClient)
     {
        MailMessage mail = new MailMessage();
        ...
        smtpClient.Send(mail);
     }

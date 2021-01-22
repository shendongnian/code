    public static void Send(string pFrom, string pSubject, string pTo, string pBody)
    {
        System.Net.Mail.MailMessage loMail = new System.Net.Mail.MailMessage();
        System.Net.NetworkCredential loCredencial = new System.Net.NetworkCredential(MAIL_USERNAME, MAIL_PASSWORD);
        loMail.To.Add(pTo);
        loMail.Subject = pSubject;
        loMail.From = new System.Net.Mail.MailAddress(pFrom);
        loMail.IsBodyHtml = true;
        loMail.Body = pBody;
        System.Net.Mail.SmtpClient loSmtp = new System.Net.Mail.SmtpClient(MAIL_SMTP);
        loSmtp.UseDefaultCredentials = false;
        loSmtp.Credentials = loCredencial;
        loSmtp.Port = MAIL_PORT;
        loSmtp.Send(loMail);
    }

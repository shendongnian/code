    public static bool SendEmail (string smtpServer, string fromAddress, string fromDisplayName,
        string toAddress, string subject, string contents, bool important) {
        MailAddress from = new MailAddress (fromAddress, fromDisplayName);
        MailPriority priority = important ? MailPriority.High : MailPriority.Normal;
        MailMessage m = new MailMessage {
            From = from,
            Subject = subject,
            Body = contents,
            Priority = priority,
            IsBodyHtml = false
        };
        MailAddress to = new MailAddress (toAddress);
        m.To.Add (to);
        SmtpClient c = new SmtpClient (smtpServer) { UseDefaultCredentials = false };
        c.Send (m);
        return true;
    }

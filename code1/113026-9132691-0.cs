The MailMessage class implements IDiposable, so perhaps it's because you are not disposing of it?
Also, before .NET 4.0, the System.Net.Mail.SmtpClient was not disposable but in 4.0 it implements IDisposable, so you'd want to wrap it in a  using statement as well.  The code would look like:
    using (MailMessage mail = new MailMessage())
    {
        mail.From = new MailAddress("from@address.com");
        mail.To.Add(string.Join(",", to_add ));
        mail.Body = message;
        mail.Subject = "Subject Text";
    
        using (SmtpClient client = new SmtpClient("0.0.0.0"))
        {
            client.UseDefaultCredentials = true;
            client.Send(mail);
        }
    }

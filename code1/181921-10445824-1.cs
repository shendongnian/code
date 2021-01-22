    private static bool testsendemail(MailMessage message)
    {
        try
        {
            MailMessage message1 = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            MailAddress fromAddress = new MailAddress("FromMail@Test.com");
            message1.From = fromAddress;
            message1.To.Add("ToMail@Test1.com");
            message1.Subject = "This is Test mail";
            message1.IsBodyHtml = true;
            message1.Body ="You can write your body here" + message;
            // We use yahoo as our smtp client
            smtpClient.Host = "smtp.mail.yahoo.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = false;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(
                "SenderMail@yahoo.com",
                "YourPassword"
            );
            smtpClient.Send(message1);
        }
        catch
        {
            return false;
        }
        return true;
    }     

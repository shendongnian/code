    using System.Net;
    using System.Net.Mail;
    
    using(SmtpClient smtpClient = new SmtpClient())
    {
        var basicCredential = new NetworkCredential("username", "password"); 
        using(MailMessage message = new MailMessage())
        {
            MailAddress fromAddress = new MailAddress("from@yourdomain.com"); 
    
            smtpClient.Host = "mail.mydomain.com";
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
    
            message.From = fromAddress;
            message.Subject = "your subject";
            // Set IsBodyHtml to true means you can send HTML email.
            message.IsBodyHtml = true;
            message.Body = "<h1>your message body</h1>";
            message.To.Add("to@anydomain.com"); 
    
            try
            {
                smtpClient.Send(message);
            }
            catch(Exception ex)
            {
                //Error, could not send the message
                Response.Write(ex.Message);
            }
        }
    }

        try
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(fromAddr, pass),
                EnableSsl = true
            };
            MailMessage mail = new MailMessage(fromAddr, toAddr, subject, body);
            mail.IsBodyHtml = true;
            client.Send(mail);
        }
        catch
        {
            // do something
        }

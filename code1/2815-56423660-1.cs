        MimeMessage message = new MimeMessage();
        message.From.Add(new MailboxAddress("FromName", "YOU_FROM_ADDRESS@gmail.com"));
        message.To.Add(new MailboxAddress("ToName", "YOU_TO_ADDRESS@gmail.com"));
        message.Subject = "MyEmailSubject";
        message.Body = new TextPart("plain")
        {
            Text = @"MyEmailBodyOnlyTextPart"
        };
        using (var client = new SmtpClient())
        {
            client.Connect("SERVER", 25); // 25 is port you can change accordingly
            // Note: since we don't have an OAuth2 token, disable
            // the XOAUTH2 authentication mechanism.
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            // Note: only needed if the SMTP server requires authentication
            client.Authenticate("YOUR_USER_NAME", "YOUR_PASSWORD");
            client.Send(message);
            client.Disconnect(true);
        }
    

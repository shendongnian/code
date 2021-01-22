            MailMessage Email = new MailMessage("donotreply@test.com", "receiver@test.com");
            Email.Subject = "RE: Hello World.";
            Email.Body = "Hello World";
            Email.IsBodyHtml = false;
            SmtpClient Client = new SmtpClient(SMTP_SERVER); //This will be an IP address
            Client.Send(Email);

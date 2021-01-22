    using (var mailMessage = new MailMessage(
            "fromaddress@blah.com", 
            "toaddress@blah.com", 
            "",
            "fromaddress@blah.com",
            "subject", 
            "body"))
    {
        var smtpClient = new SmtpClient("SmtpHost")
        {
            EnableSsl = false,
            DeliveryMethod = SmtpDeliveryMethod.Network
        };
    
        // Apply credentials
        smtpClient.Credentials = new NetworkCredential("smtpUsername", "smtpPassword");
    
        // Send
        smtpClient.Send(mailMessage);
    }

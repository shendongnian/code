    public async Task SendEmail(string toEmailAddress, string emailSubject, string emailMessage)
    {
        var message = new MailMessage();
        message.To.Add(toEmailAddress);
    
        message.Subject = emailSubject;
        message.Body = emailMessage;
    
        using (var smtpClient = new SmtpClient())
        {
            await smtpClient.SendMailAsync(message);
        }
    } 

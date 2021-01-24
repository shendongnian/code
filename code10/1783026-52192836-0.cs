    public async Task Send(string to, string subject, string body)
    {
        var message = new MailMessage
        {
            Subject = subject,
            Body = body
        };
        message.To.Add(to);
    
        using (var smtpClient = new SmtpClient())
        {
            await smtpClient.SendMailAsync(message);
        }
    } 

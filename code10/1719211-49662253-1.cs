    public async Task MailingFunctionAsync(string toEmailAddress)
    {
        var message = new MailMessage();
        message.To.Add(toEmailAddress);
        message.Subject = SOME_SUBJECT;
        message.Body = SOME_BODY;
        using (var smtpClient = new SmtpClient())
        {
            await smtpClient.SendMailAsync(message);
        }
    }

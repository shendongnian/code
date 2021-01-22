    BackgroundTaskRunner.FireAndForgetTaskAsync(async () =>
    {
        SmtpClient smtpClient = new SmtpClient(); // using configuration file settings
        MailMessage message = new MailMessage(); // TODO: Initialize appropriately
        await smtpClient.SendMailAsync(message);
    });

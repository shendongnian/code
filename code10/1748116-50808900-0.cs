    static async Task SendAsync(SmtpClientFactory factory, IEnumerable<MailMessage> messages, CancellationToken token)
    {
        await Task.Run(async () =>
        {
            using (SmtpClient smtpClient = factory())
            {
                foreach (MailMessage message in messages)
                {
                    token.ThrowIfCancellationRequested();
                    using (token.Register(() => smtpClient.SendAsyncCancel()))
                    {
                        await smtpClient.SendMailAsync(message).ConfigureAwait(false);
                    }
                }
            }
        }, token);
    }

    private async Task SendFromServer(MailMessage mailMessage) {
        using (var smtp = new SmtpClient()) {
            try {
                await smtp.SendMailAsync(mailMessage);
            } catch (Exception ex) {
                Logger.Error(ex.InnerException ?? ex);
            }
        }
    }

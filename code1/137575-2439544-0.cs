    MailMessage message = new MailMessage();
    // Very basic html. HTML should always be valid, otherwise you go to spam
    message.Body = "<html><body><p>test</p></body></html>"; 
    message.BodyEncoding = Encoding.UTF8; // QuotedPrintable will be trouble
    message.IsBodyHtml = true;
    message.Subject = "Some Subject";
    message.To.Add("someone@gmail.com");
    SmtpClient client = new SmtpClient(SmtpHost, SmtpPort) {
                Credentials = new NetworkCredential(SmtpUser, SmtpPassword),
                EnableSsl = enableSsl;
            };
            try {
                // It might be necessary to enforce a specific sender address
                if (!string.IsNullOrEmpty(ForceSenderAddress)) {
                    message.From = new MailAddress(ForceSenderAddress);
                }
                client.Send(message);
            }
            catch (Exception ex) {
                return false;
            }

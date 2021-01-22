    MailMessage message = new MailMessage();
    // Very basic html. HTML should always be valid, otherwise you go to spam
    message.Body = "<html><body><p>test</p></body></html>"; 
    // QuotedPrintable encoding is the default, but will often lead to trouble, 
    // so you should set something meaningful here. Could also be ASCII or some ISO
    message.BodyEncoding = Encoding.UTF8;
    message.IsBodyHtml = true;
    // No Subject usually goes to spam, too
    message.Subject = "Some Subject";
    // Note that you can add multiple recipients, bcc, cc rec., etc. Using the 
    // address-only syntax, i.e. w/o a readable name saves you from some issues
    message.To.Add("someone@gmail.com");
    // SmtpHost, -Port, -User, -Password must be a valid account you can use to 
    // send messages. Note that it is very often required that the account you
    // use also has the specified sender address associated! 
    // If you configure the Smtp yourself, you can change that of course
    SmtpClient client = new SmtpClient(SmtpHost, SmtpPort) {
                Credentials = new NetworkCredential(SmtpUser, SmtpPassword),
                EnableSsl = enableSsl;
            };
            try {
                // It might be necessary to enforce a specific sender address, see above
                if (!string.IsNullOrEmpty(ForceSenderAddress)) {
                    message.From = new MailAddress(ForceSenderAddress);
                }
                client.Send(message);
            }
            catch (Exception ex) {
                return false;
            }

    // Create and build a new MailMessage object
    MailMessage message = new MailMessage();
    message.IsBodyHtml = true;
    message.From = new MailAddress(FROM,FROMNAME);
    message.To.Add(new MailAddress(TO));
    message.Subject = SUBJECT;
    message.Body = BODY;
    // Comment or delete the next line if you are not using a configuration set
    message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

    // Connect to Exchange Web Services as user1 at contoso.com.
    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
    service.Credentials = new WebCredentials("user1@contoso.com", "password ");
    service.AutodiscoverUrl("user1@contoso.com");
    
    // Create the e-mail message, set its properties, and send it to user2@contoso.com, saving a copy to the Sent Items folder. 
    EmailMessage message = new EmailMessage(service);
    message.Subject = "Interesting";
    message.Body = "The proposition has been considered."; 
    message.ToRecipients.Add("user2@contoso.com");
    message.SendAndSaveCopy();

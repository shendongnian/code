    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
    // In case you have a dodgy SSL certificate:
    System.Net.ServicePointManager.ServerCertificateValidationCallback =
                delegate(Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                {
                    return true;
                };
				
    service.Credentials = new WebCredentials("username", "password", "MYDOMAIN");
    service.Url = new Uri("https://exchangebox/EWS/Exchange.asmx");
	
    EmailMessage em = new EmailMessage(service);
    em.Subject = "example email";
    em.Body = new MessageBody("hello world");
    em.Sender = new Microsoft.Exchange.WebServices.Data.EmailAddress("john.smith@example.com");
    em.ToRecipients.Add(new Microsoft.Exchange.WebServices.Data.EmailAddress("bob.smith@example.com"));
    // Send the email and put it into the SentItems:
    em.SendAndSaveCopy(WellKnownFolderName.SentItems);

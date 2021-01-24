    var secrets = new ClientSecrets
    {
    	ClientId = Environment.GetEnvironmentVariable("GMailClientId"),
    	ClientSecret = Environment.GetEnvironmentVariable("GMailClientSecret")
    };
    
    var googleCredentials = await GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, new[] { GmailService.Scope.MailGoogleCom }, email, CancellationToken.None);
    if (googleCredentials.Token.IsExpired(SystemClock.Default))
    {
    	await googleCredentials.RefreshTokenAsync(CancellationToken.None);
    }
    
    using (var client = new SmtpClient())
    {
    	client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
    
    	var oauth2 = new SaslMechanismOAuth2(googleCredentials.UserId, googleCredentials.Token.AccessToken);
    	client.Authenticate(oauth2);
    
    	await client.SendAsync(message);
    	client.Disconnect(true);
    }

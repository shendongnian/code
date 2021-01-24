    String AADTenantId = "";
    String AppGuid = "";
    String SenderAddress = "";
    String SenderId = "";
    String ToAddress = "";
    String SubjectText = "";
    String BodyText = "";
    Byte[] Certificate = ...GetCertBytes...
    String CertPassword = "";
    var client = new GraphServiceClient(new DelegateAuthenticationProvider(
        async requestMessage =>
        {
            var authContext = new AuthenticationContext($"https://login.microsoftonline.com/{AADTenantId}");
            var cert = new X509Certificate2(Certificate, CertPassword);
            var clientAssertion = new ClientAssertionCertificate(AppGuid, cert);
            AuthenticationResult authresult = await authContext.AcquireTokenAsync("https://graph.microsoft.com", clientAssertion);
            // Append the access token to the request
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authresult.AccessToken);
        }));
    var sender = new Recipient()
    {
        EmailAddress = new EmailAddress() { Address = SenderAddress }
    };
    var email = new Message
    {
        Sender = sender,
        From = sender,
        Subject = SubjectText,
        Body = new ItemBody()
        {
            Content = BodyText,
            ContentType = BodyType.Text
        },
        ToRecipients = new List<Recipient>() {
            new Recipient() { EmailAddress = new EmailAddress { Address = ToAddress }}
        }
    };
    await client.Users[SenderId].SendMail(email, true).Request().PostAsync();
        

     Notifications = new OpenIdConnectAuthenticationNotifications()
                        {
                       
    
     AuthorizationCodeReceived = (context) => private static string appKey = ConfigurationManager.AppSettings["ida:ClientSecret"];
            
     ClientCredential credential = new ClientCredential(clientId, appKey);
     
     string signedInUserID = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;
    ...

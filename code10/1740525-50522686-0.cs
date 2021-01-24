    string graphResourceId = "https://graph.microsoft.com/";
    string authority = "https://login.microsoftonline.com/{0}";
    string tenantId = "tenant Id";
    string clientId = "client Id";
    string secret = "secret";
    authority = String.Format(authority, tenantId);
    AuthenticationContext authContext = new AuthenticationContext(authority);
    var accessToken = authContext.AcquireTokenAsync(graphResourceId, new ClientCredential(clientId, secret)).Result.AccessToken;
                var graphserviceClient = new GraphServiceClient(
                    new DelegateAuthenticationProvider(
                        requestMessage =>
                        {
                            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
    
                            return Task.FromResult(0);
                        }));
    var user = new User
             {
                 UserPrincipalName = "tomaccount1@xxxxx.onmicrosoft.com",
                 AccountEnabled = true,
                 DisplayName = "tom1",
                 PasswordProfile = new PasswordProfile
                 {
                     ForceChangePasswordNextSignIn = true,
                     Password = "1234qweA!@#$%6"
                 },
                  MailNickname = "tomaccount1"
                };
     var addUserResult = graphserviceClient.Users.Request().AddAsync(user).Result;

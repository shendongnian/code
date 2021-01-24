     private static async Task<string> GetAppTokenAsync(string graphResourceId, string tenantId, string clientId, string userId)
            {
    
                string aadInstance = "https://login.microsoftonline.com/" + tenantId + "/oauth2/token";
                IPlatformParameters parameters = new PlatformParameters(PromptBehavior.SelectAccount);
                AuthenticationContext authenticationContext = new AuthenticationContext(aadInstance, false);
                var authenticationResult = await authenticationContext.AcquireTokenAsync(graphResourceId, clientId, new Uri("http://localhost"), parameters, new UserIdentifier(userId, UserIdentifierType.UniqueId));
                return authenticationResult.AccessToken;
            }
     var graphResourceId = "https://graph.windows.net";
     var tenantId = "tenantId";
     var clientId = "clientId";
     var userId= "313e5ee2-b28exx-xxxx"; Then login user
     var servicePointUri = new Uri(graphResourceId); 
     var serviceRoot = new Uri(servicePointUri, tenantId);
     var activeDirectoryClient = new ActiveDirectoryClient(serviceRoot, async () => await GetAppTokenAsync(graphResourceId, tenantId, clientId, userName));
     var cert = new X509Certificate();
     cert.Import(@"D:\Tom\Documents\tom.cer");// the path fo cert file
     var expirationDate  = DateTime.Parse(cert.GetExpirationDateString()).ToUniversalTime();
     var startDate = DateTime.Parse(cert.GetEffectiveDateString()).ToUniversalTime();
     var binCert =cert.GetRawCertData();
     var keyCredential = new KeyCredential
          {
                    CustomKeyIdentifier = cert.GetCertHash(),
                    EndDate = expirationDate,
                    KeyId = Guid.NewGuid(),
                    StartDate = startDate,
                    Type = "AsymmetricX509Cert",
                    Usage = "Verify",
                    Value = binCert
    
            };
       var application = activeDirectoryClient.Applications["ApplicationObjectId"].ExecuteAsync().Result;
       application.KeyCredentials.Add(keyCredential);
       application.UpdateAsync().Wait();

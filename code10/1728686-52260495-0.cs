      var clientcred = new ClientCredential(clientId, clientSecret);
                    AuthenticationContext authContext = new AuthenticationContext(aadInstance, false);
                    AuthenticationResult result = authContext.AcquireToken(organizationUrl, clientcred);
                
                 
                    token = result.AccessToken;
                    ExpireDate = result.ExpiresOn.DateTime;
              
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

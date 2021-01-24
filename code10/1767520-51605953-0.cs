            string authority = "https://login.microsoftonline.com/b29343ba-***/oauth2/token"; //token endpoint
            string resourceUri = "";
            string clientId = "your application id";
            string clientkey = "your app key";
            try
            {
                AuthenticationContext authContext = new AuthenticationContext(authority);
                ClientCredential clientCredential = new ClientCredential(clientId, clientkey);
                AuthenticationResult authenticationResult = authContext.AcquireTokenAsync(resourceUri, clientCredential).Result;
                Console.WriteLine("--------------------------------");
                Console.WriteLine(authenticationResult.AccessToken);
                Console.Read();
            }
            catch (Exception ex)
            {
            }

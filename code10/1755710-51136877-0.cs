       private static UserCredential GetUserCredential(string clientSecretJson, string userName, string[] scopes)
            {
                try
                {
                    if (string.IsNullOrEmpty(userName))
                        throw new ArgumentNullException("userName");
                    if (string.IsNullOrEmpty(clientSecretJson))
                        throw new ArgumentNullException("clientSecretJson");
                    if (!File.Exists(clientSecretJson))
                        throw new Exception("clientSecretJson file does not exist.");
    
                    // These are the scopes of permissions you need. It is best to request only what you need and not all of them               
                    using (var stream = new FileStream(clientSecretJson, FileMode.Open, FileAccess.Read))
                    {
                        string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                        credPath = Path.Combine(credPath, ".credentials/", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
    
                        // Requesting Authentication or loading previously stored authentication for userName
                        var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                                                                                 scopes,
                                                                                 userName,
                                                                                 CancellationToken.None,
                                                                                 new FileDataStore(credPath, true)).Result;
    
                        credential.GetAccessTokenForRequestAsync();
                        return credential;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Get user credentials failed.", ex);
                }
            }

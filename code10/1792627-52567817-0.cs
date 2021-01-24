    public static async Task DeleteEmail(string emailId)
            {
                TokenCache tokens = TokenCacheHelper.GetUserCache();
                PublicClientApplication clientApp = new PublicClientApplication(secret, RootAuthUri, tokens);
    
                using (HttpClient c = new HttpClient())
                {
                    string requestURI = RootUri + "/me/messages/" + emailId;
    
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, requestURI);
                    //Authentication token
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetTokenAsync(clientApp));
    
                    HttpResponseMessage response = await c.SendAsync(request);
                    string responseString = await response.Content.ReadAsStringAsync();
                }
    
            }
    private static async Task<string> GetTokenAsync(PublicClientApplication app)
            {
                AuthenticationResult result = null;
                string[] scopes = { "User.Read", "Mail.ReadWrite" };
                try
                {
    
                    // Get the token from the cache.
                    result = await app.AcquireTokenSilentAsync(scopes, (await app.GetAccountsAsync()).FirstOrDefault());
                    return result.AccessToken;
                }
                catch (MsalUiRequiredException ex)
                {
                    // A MsalUiRequiredException happened on AcquireTokenSilentAsync. 
                    // This indicates you need to call AcquireTokenAsync to acquire a token
                    Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");
    
                    try
                    {
                        // Dialog opens for user.
                        result = await app.AcquireTokenAsync(scopes);
                        return result.AccessToken;
                    }
                    catch (MsalException msalex)
                    {
                        Debug.WriteLine($"Error Acquiring Token:{System.Environment.NewLine}{msalex}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}");
                    return null;
                }
            }
    static class TokenCacheHelper
        {
    
            /// <summary>
            /// Get the user token cache
            /// </summary>
            /// <returns></returns>
            public static TokenCache GetUserCache()
            {
                if (usertokenCache == null)
                {
                    usertokenCache = new TokenCache();
                    usertokenCache.SetBeforeAccess(BeforeAccessNotification);
                    usertokenCache.SetAfterAccess(AfterAccessNotification);
                }
                return usertokenCache;
            }
    
            static TokenCache usertokenCache;
    
            /// <summary>
            /// Path to the token cache
            /// </summary>
            public static readonly string CacheFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location + ".msalcache.bin";
    
            private static readonly object FileLock = new object();
    
            public static void BeforeAccessNotification(TokenCacheNotificationArgs args)
            {
                
                lock (FileLock)
                {
                    args.TokenCache.Deserialize(File.Exists(CacheFilePath)
                        ? ProtectedData.Unprotect(File.ReadAllBytes(CacheFilePath),
                                                  null,
                                                  DataProtectionScope.CurrentUser)
                        : null);
                }
            }
    
            public static void AfterAccessNotification(TokenCacheNotificationArgs args)
            {
                // if the access operation resulted in a cache update
                if (args.TokenCache.HasStateChanged)
                {
                    lock (FileLock)
                    {
                        // reflect changesgs in the persistent store
                        File.WriteAllBytes(CacheFilePath,
                                           ProtectedData.Protect(args.TokenCache.Serialize(),
                                                                 null,
                                                                 DataProtectionScope.CurrentUser)
                                          );
                        // once the write operationtakes place restore the HasStateChanged bit to filse
                        args.TokenCache.HasStateChanged = false;
                    }
                }
            }
        }

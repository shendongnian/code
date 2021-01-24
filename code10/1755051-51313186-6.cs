    public class KerberosTokenCacher
    {
        public KerberosTokenCacher()
        {
        }
        public KerberosReceiverSecurityToken WriteToCache(string contextUsername, string contextPassword)
        {
            KerberosSecurityTokenProvider provider =
                            new KerberosSecurityTokenProvider("YOURSPN",
                            TokenImpersonationLevel.Impersonation,
                            new NetworkCredential(contextUsername.ToLower(), contextPassword, "yourdomain"));
            KerberosRequestorSecurityToken requestorToken = provider.GetToken(TimeSpan.FromMinutes(double.Parse(ConfigurationManager.AppSettings["KerberosTokenExpiration"]))) as KerberosRequestorSecurityToken;
            KerberosReceiverSecurityToken receiverToken = new KerberosReceiverSecurityToken(requestorToken.GetRequest());
            IAppCache appCache = new CachingService();
            KerberosReceiverSecurityToken tokenFactory() => receiverToken;
            return appCache.GetOrAdd(contextUsername.ToLower(), tokenFactory); // this will either add the token or get the token if it exists
        }
        public KerberosReceiverSecurityToken ReadFromCache(string contextUsername)
        {
            IAppCache appCache = new CachingService();
            KerberosReceiverSecurityToken token = appCache.Get<KerberosReceiverSecurityToken>(contextUsername.ToLower());
            return token;
        }
        public void DeleteFromCache(string contextUsername)
        {
            IAppCache appCache = new CachingService();
            KerberosReceiverSecurityToken token = appCache.Get<KerberosReceiverSecurityToken>(contextUsername.ToLower());
            if(token != null)
            {
                appCache.Remove(contextUsername.ToLower());
            }
        }
    }

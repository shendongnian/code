    public class ProvidersManager
    {
        IProviderInterface ProviderObj;
    
        public ProvidersManager(IProviderInterface providerObj)
        {
            ProviderObj = providerObj;
        }
    
        public string GetRedirectUrl()
        {
            return  ProviderObj.GetRedirectUrl();
        }
    
        public string GetStatus()
        {
            return ProviderObj.GetStatus();
        }
    }

    internal static class ProviderManager
    {
    	private Dictionary<string, BaseProvider> _providers = new Dictionary<string, BaseProvider>();
    	
    	public static void Register(string name, BaseProvider provider)
    	{
    		_providers.Add(name, provider);
    	}
    	
    	public string GetRedirectUrl(string name) => _providers[name].GetRedirectUrl();
    	public string GetStatus(string name) => _providers[name].GetStatus();
    }

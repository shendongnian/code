    internal static class ProviderManager
    {
    	private static readonly Dictionary<string, BaseProvider> _providers = new Dictionary<string, BaseProvider>();
    	
    	public static void Register(string name, BaseProvider provider) => _providers.Add(name, provider);
    	public static string GetRedirectUrl(string name) => _providers[name].GetRedirectUrl();
    	public static string GetStatus(string name) => _providers[name].GetStatus();
    }

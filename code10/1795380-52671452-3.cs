    internal class Program
    {
    	public static void Main(string[] args)
    	{
    		ProviderA providerA = new ProviderA("http://stackoverflow.com", "active");
    		string url = ProviderManager.GetRedirectUrl("A");
    	}
    }

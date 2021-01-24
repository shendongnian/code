    internal abstract class BaseProvider
    {
    	private BaseProvider(string name)
    	{
    		ProviderManager.Register(name, this);
    	}
    	
    	public abstract string GetRedirectUrl();
    	public abstract string GetStatus();
    }

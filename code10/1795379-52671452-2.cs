    internal class ProviderA : BaseProvider
    {
    	private readonly string _redirectUrl;
    	private readonly string _status;
    	
    	public ProviderA(string redirectUrl, string status) : base("A")
    	{
    		_redirectUrl = redirectUrl
    		_status = status;
    	}
    	
    	public string GetRedirectUrl() => _redirectUrl;
    	public string GetStatus() => _status;
    }

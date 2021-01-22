    private void RegisterFtps()
    {
    	WebRequest.RegisterPrefix("ftps", new FtpsWebRequestCreator());
    }
    private sealed class FtpsWebRequestCreator : IWebRequestCreate
    {
    	public WebRequest Create(Uri uri)
    	{
    		FtpWebRequest webRequest = (FtpWebRequest)WebRequest.Create(uri.AbsoluteUri.Remove(3, 1)); // Removes the "s" in "ftps://".
    		webRequest.EnableSsl = true;
    		return webRequest;
    	}
    }

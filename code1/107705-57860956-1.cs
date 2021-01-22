    public class WebClientWithTimeout : WebClient
    {
    	//10 secs default
    	public int Timeout { get; set; } = 10000;
    
    	//for sync requests
    	protected override WebRequest GetWebRequest(Uri uri)
    	{
    		var w = base.GetWebRequest(uri);
    		w.Timeout = Timeout; //10 seconds timeout
    		return w;
    	}
    
    	//the above will not work for async requests :(
    	//let's create a workaround by hiding the method
        //and creating our own version of DownloadStringTaskAsync
    	public new async Task<string> DownloadStringTaskAsync(Uri address)
    	{
    		var t = base.DownloadStringTaskAsync(address);
    		if(await Task.WhenAny(t, Task.Delay(Timeout)) != t) //time out!
    		{
    			CancelAsync();
    		}
    		return await t;
    	}
    }

    string html = new Func<string>(() =>
    {
    	string webpage;
    
    	try
    	{
    		using(WebClient downloader = new WebClient())
    		{
    			webpage = downloader.DownloadString(url);
    		}
    	}
    	catch(WebException)
    	{
    		Console.WriteLine("Download failed.");  
    	}
    
    	return webpage;
    })();

    private string GetPublicIpAddress()
    {
    	var request = (HttpWebRequest)WebRequest.Create("http://ifconfig.me");
    
    	request.UserAgent = "curl"; // this will tell the server to return the information as if the request was made by the linux "curl" command
    
    	string publicIPAddress;
    
    	request.Method = "GET";
    	using (WebResponse response = request.GetResponse())
    	{
    		using (var reader = new StreamReader(response.GetResponseStream()))
    		{
    			publicIPAddress = reader.ReadToEnd();
    		}
    	}
    
    	return publicIPAddress.Replace("\n", "");
    }

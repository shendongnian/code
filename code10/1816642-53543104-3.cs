    public List<string> GetGridInfo()
    {
    	string URI = "http://localhost/api/getinfo";
    
    	using (var webClient = new System.Net.WebClient())
    	{
    		var json = webClient.DownloadString(URI);
    
    		var message = JsonConvert.DeserializeObject<List<string>>(json);
    
    		return message;
    	}
    }
 

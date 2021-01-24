    private const string Url = "https://localhost:44310/api/stock";
    
    private HttpClient _client = new HttpClient();
    
    protected async void OnGetList()
    {
    	if (CrossConnectivity.Current.IsConnected)
    	{
    		try 
    		{
    			var content = await _client.GetStringAsync(Url);
    			
    			var list = JsonConvert.DeserializeObject<List<Model>>(content);
    		} 
    		catch (Exception e)
    		{
    			Debug.WriteLine("", e);
    		}
    	}
    }

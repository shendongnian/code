    static async Task<string> MainAsync()
    {
        //Added this to decompress the gzip encoded response
    	HttpClientHandler handler = new HttpClientHandler();
    	handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip;
    
    	var client = new HttpClient(handler);
    	var request = new HttpRequestMessage()
    	{
    		Method = HttpMethod.Get, 
    		RequestUri = new Uri("https://www.staples.com"),
    		Version = new Version(1, 1)
    	};
    	
    	request.Headers.Connection.Add("keep-alive");
    	request.Headers.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("en-GB"));
    	
    	var response = await client.SendAsync(request);
    	return await response.Content.ReadAsStringAsync();
    }

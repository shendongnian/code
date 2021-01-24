    static async Task<string> MainAsync()
    {
    	var client = new HttpClient();
    	var request = new HttpRequestMessage()
    	{
    		Method = HttpMethod.Get, 
    		RequestUri = new Uri("https://www.staples.com"),
    		Version = new Version(1, 1)
    	};
    	
    	request.Headers.Connection.Add("keep-alive");
    	request.Headers.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
    	request.Headers.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("en-GB"));
    	
    	var response = await client.SendAsync(request);
    	return await response.Content.ReadAsStringAsync();
    }

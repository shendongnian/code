        HttpClient httpClient = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage();
        request.RequestUri = "Your_get_URI";
        request.Method = HttpMethod.Get;
    	request.Headers.Add("api_key", "1234");
    	HttpResponseMessage response =  await httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var statusCode = response.StatusCode;
    

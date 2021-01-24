    public async void SendPostMethod(string url, Dictionary<string, string> param, Action<string> response)
    {
        HttpClient client = new HttpClient();
        
        HttpResponseMessage httpResponse = new HttpResponseMessage();
        Uri requestUri = new Uri(url);
    
        var content = new HttpFormUrlEncodedContent(param);
        try
        {
            httpResponse = await client.PostAsync(requestUri, content);
    
            response(await httpResponse.Content.ReadAsStringAsync());
        }
        catch (Exception ex)
        {
    
        }
    
    }

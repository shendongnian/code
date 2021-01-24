    private static HttpClient client = new HttpClient();
    public static async void GetResponse()
    {
    	string key = Properties.Settings.Default.Key;
    
    	Uri imgUri = new Uri($"https://dev.virtualearth.net/REST/v1/Imagery/Map/Road/Redmond Washington?ms=500,270&zl=12&&c=en-US&he=1&fmt=png&key={key}");
    
    	HttpResponseMessage response = await client.GetAsync(imgUri);
    	response.EnsureSuccessStatusCode();
    	byte[] responseData = await response.Content.ReadAsByteArrayAsync();
    
    	File.WriteAllBytes("test.png", responseData);
    }
    

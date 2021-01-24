    public async Task SendDataAsync(string fullFilePath)
    {
        if (!File.Exists(fullFilePath))
        	throw new FileNotFoundException();
    	var data = JsonConvert.SerializeObject(new UploadedFile(fullFilePath));
        using (var client = new WebClient())
        {
         	client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
    	    await client.UploadStringTaskAsync(new Uri("http://localhost:64204/api/upload/"), "POST", data);
        }
    }

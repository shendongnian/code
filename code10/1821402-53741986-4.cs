    public async Task SendDataAsync(string fullFileName)
    {
        if (!File.Exists(fullFileName))
        	throw new FileNotFoundException;
    	var client = new HttpClient();
    	client.BaseAddress = new Uri("http://x.x.x.x");
        var file = new UploadedFile(fullFileName);
        var data = JsonConvert.SerializeObject(file);    	
        var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
    	
        await client.PostAsync("/destination/action", content);
    }

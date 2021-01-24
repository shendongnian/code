    public async Task SendDataAsync(string fullFileName)
    {
    	var client = new HttpClient();
    	client.BaseAddress = new Uri("http://x.x.x.x");
        var file = new UploadedFile("C:\temp\image.jpg");
        var data = JsonConvert.SerializeObject(file);    	
        var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
    	
        await client.PostAsync("/destination/action", content);
    }

    async void Main()
    {
    	using (var client = new HttpClient())
    	{
    		var tasks = new List<Task>();
    		var files = new Dictionary<string, string>();
    		files.Add("c:\\temp\\MyFilename1.md", "https://raw.githubusercontent.com/aspnet/AspNetCore/master/README.md");
    		files.Add("c:\\temp\\MyFilename2.md", "https://raw.githubusercontent.com/aspnet/AspNetCore/master/README.md");
    
    		foreach (var file in files)
    		{
    			tasks.Add(DownloadFileAsync(client, file.Key, file.Value));
    		}
    
    		await Task.WhenAll(tasks);
    	}
    }
    
    async Task DownloadFileAsync(HttpClient client, string filename, string url)
    {
    	var contents = await client.GetStringAsync(url);
    	File.WriteAllText(filename, contents);
    }

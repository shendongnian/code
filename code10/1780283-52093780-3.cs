    private static readonly List<Uri> Urls = new List<Uri>() {
        new Uri(""),
        new Uri("") };
    ....
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    var result1 = Urls.Select(GetContent).ToArray();
    stopwatch.Stop();
    Console.WriteLine($@"Synchronous and NOT In Parallel:{stopwatch.ElapsedMilliseconds}");
    
    stopwatch.Restart();
    var result2 = Urls.AsParallel().Select(GetContent).ToArray();
    stopwatch.Stop();
    Console.WriteLine($@"Synchronous and In Parallel:{stopwatch.ElapsedMilliseconds}");
    
    stopwatch.Restart();
    var task1 = DoAsyncNotParallel();
    task1.Wait();
    stopwatch.Stop();
    Console.WriteLine($@"Asynchronous and NOT In Parallel:{stopwatch.ElapsedMilliseconds}");
    
    stopwatch.Restart();
    var task2 = DoAsyncInParallel();
    task2.Wait();
    stopwatch.Stop();
    Console.WriteLine($@"Asynchronous and In Parallel:{stopwatch.ElapsedMilliseconds}");
    
    static async Task<string[]> DoAsyncNotParallel()
    {
    	List<string> content = new List<string>();
    	foreach (var uri in Urls)
    	{
    		content.Add(await GetContentAsync(uri));
    	}
    
    	return content.ToArray();
    }
    
    static async Task<string[]> DoAsyncInParallel()
    {
    	var tasks = Urls.Select(uri => GetContentAsync(uri));
    
    	var content = await Task.WhenAll(tasks);
    
    	return content;
    }
    private static async Task<string> GetContentAsync(Uri uri)
    {
    	HttpClient httpClient = new HttpClient();
    	var response = await httpClient.GetAsync(uri);
    	var content = await response.Content.ReadAsStringAsync();
    	return content;
    }
    
    
    private static string GetContent(Uri uri)
    {
    	HttpClient httpClient = new HttpClient();
    	var response = httpClient.GetAsync(uri).Result;
    	var content = response.Content.ReadAsStringAsync().Result;
    	return content;
    }
       

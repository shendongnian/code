    static void Main()
    {
    	Console.WriteLine("Enter Url you want to Extract data from");
    	string userInput = Console.ReadLine();
        Task t = new Task(DownloadPageAsync);
        t.Start();
        Console.WriteLine("Downloading page...");
        Console.ReadLine();
    }
    
    static async void DownloadPageAsync(string requestUrl)
    {
        // ... Use HttpClient instead of webclient
        using (HttpClient client = new HttpClient())
        using (HttpResponseMessage response = await client.GetAsync(requestUrl))
        using (HttpContent content = response.Content)
        {
            string mydata = await content.ReadAsStringAsync();
    		Regex regex = new Regex("href[\\s]*=[\\s]*\"(.*?)[\\s]*\\\"");
    		foreach (Match htmlPath in regex.Matches(mydata))
    		{
    		    // Here you can write your custom logic
    			Console.WriteLine(htmlPath.Groups[1].Value);
    		}
        }
    }

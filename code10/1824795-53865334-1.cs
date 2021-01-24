	async void Main()
	{
		var wc = new State<WebClient>(new WebClient());
	
		string source = await wc.SelectAsync<string>(x => x.DownloadStringTaskAsync(new Uri("http://www.microsoft.com")));
	
		Console.WriteLine(source);
	}

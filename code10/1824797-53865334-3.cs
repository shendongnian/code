	async void Main()
	{
		var wc = new State<WebClient>(new WebClient());
	
		string source = wc.Select<string>(x => x.DownloadString(new Uri("http://www.microsoft.com")));
	
		Console.WriteLine(source);
	}

	public async Task PushEventReader()
	{
	    var uri = "url.to/api";
	    using (var client = new WebClient())
	    {
	        client.OpenReadCompleted += async (sender, e) =>
	        {
	            using (var reader = new StreamReader(e.Result))
	            {
	                while (!reader.EndOfStream)
	                {
	                    var line = await reader.ReadLineAsync();
	                    Console.WriteLine(line);
	                }
	            }
	        };
	        await client.OpenReadTaskAsync(new Uri(uri));
	    }
	}

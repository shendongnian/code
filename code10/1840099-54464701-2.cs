	async void DownloadPagesAsync() {
	
		for (var i = 1; i < 3; i++) {
		
			var pageToGet = $"https://jsonplaceholder.typicode.com/todos/{i}";
	
		    using (var client = new HttpClient())
		    using (HttpResponseMessage response = await client.GetAsync(pageToGet))
		    using (HttpContent content = response.Content)
			using (var stream = (MemoryStream) await content.ReadAsStreamAsync()) 
			using (var sr = new StreamReader(stream))
			while (!sr.EndOfStream) {
				
				var row = 
					sr.ReadLine()
					.Replace(@"""", "")
					.Replace(",", "");
				
				if (row.IndexOf(":") == -1)
					continue;
				
				var values = row.Split(':');
				Console.WriteLine($"{values[0]}, {values[1]}");
							
		    }
	
		}
			
	}

	using (var httpClient = new HttpClient())
	{
		using (var responseTextTask = httpClient.GetStringAsync("http://google.com"))
		{
			responseTextTask.Wait();
			string responseText = responseTextTask.Result;
		}
	}

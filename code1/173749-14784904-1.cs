	using (var httpClient = new HttpClient())
	{
		using (var responseTextTask = httpClient.GetStringAsync(url))
		{
			responseTextTask.Wait();
			string responseText = responseTextTask.Result;
		}
	}

    static void Main(string[] args)
	{
		using (HttpClient httpClient = new HttpClient())
		{
			var someData = JsonConvert.SerializeObject(new { Id = "test" });
			var content = new StringContent(someData, System.Text.Encoding.UTF8, "application/json");
			var result = httpClient.PostAsync("http://localhost:55878/api/values", content).Result;
			if (result.IsSuccessStatusCode)
			{
				Console.WriteLine("All is fine");
			}
			else
			{
				Console.WriteLine($"Something was wrong. HttpStatus: {result.StatusCode}");
			}
		}
		Console.ReadKey();
	}

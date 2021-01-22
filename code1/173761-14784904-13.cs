	public static async Task<string> GetResponseText(string address)
	{
		using (var httpClient = new HttpClient())
			return await httpClient.GetStringAsync(address);
	}

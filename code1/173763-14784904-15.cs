	private static readonly HttpClient httpClient = new HttpClient();
	
	public static async Task<string> GetResponseText(string address)
	{
		return await httpClient.GetStringAsync(address);
	}

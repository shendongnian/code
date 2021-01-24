    public class ApiClient {
    	private HttpClient _client;
    
    	public ApiClient()
    	{
    		var webHostBuilder = new WebHostBuilder();
    		webHostBuilder.UseEnvironment("Test");
    		webHostBuilder.UseStartup<Startup>();
    		var server = new TestServer(webHostBuilder);
    		_client = server.CreateClient();
    	}
    
    	public async Task<HttpResponseMessage> PostAsync<T>(string url, T entity)
    	{
    		var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
    		return await _client.PostAsync(url, content);
    	}
    
    	public async Task<T> GetAsync<T>(string url)
    	{
    		var response = await _client.GetAsync(url);
    		response.EnsureSuccessStatusCode();
    		var responseString = await response.Content.ReadAsStringAsync();
    		return JsonConvert.DeserializeObject<T>(responseString);
    	}
    }

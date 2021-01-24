    public class StreamerController : ApiController
    {
    	static readonly JsonSerializer _serializer = new JsonSerializer();
    	static readonly HttpClient _client = new HttpClient();
    
    	[HttpPost]
    	[Route("streamer/stream")]
    	public async Task<IHttpActionResult> stream()
    	{
    		string apiUrl = "https://raw.githubusercontent.com/ysharplanguage/FastJsonParser/master/JsonTest/TestData/fathers.json.txt";
    
    		using (var stream = await _client.GetStreamAsync(apiUrl).ConfigureAwait(false))
    		using (var reader = new StreamReader(stream))
    		using (var json = new JsonTextReader(reader))
    		{
    			if (json == null)
    				StatusCode(HttpStatusCode.InternalServerError);
    
    			JsonSerializer serializer = new JsonSerializer();
    
    			RootObject f = serializer.Deserialize<RootObject>(json);  
    		}
    
    		return StatusCode(HttpStatusCode.OK);
    	}
    }

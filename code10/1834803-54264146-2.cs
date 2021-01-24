    public string appId = "Your app-id";
    		public string consumerKey = "Your-consumer key";
    		public string consumerSecret = "Your Consumer Secret key";
    
    		// GET: api/Random
    		[HttpGet("{CityName}")]
    		public async Task<IActionResult> GetAsync([FromUri] string CityName)
    		{
    	
    
    
    
    		string urlss = "https://weather-ydn-yql.media.yahoo.com/forecastrss?location=";
    			string url = urlss + CityName+ "&format=json&u=c";
    			JObject jresult;
    			using (var client = new HttpClient())
    			{
    				try
    				{
    
    					var webClient = new WebClient();
    					webClient.Headers.Add(AssembleOAuthHeader());
    					var d = webClient.DownloadString(url);
    					jresult = JObject.Parse(d);
    					var json_jsonstring = Newtonsoft.Json.JsonConvert.SerializeObject(jresult);
    					return Ok(json_jsonstring);
    
    				}
    				catch (HttpRequestException httpRequestException)
    				{
    					return BadRequest($"Error getting weather from Yahoo Weather: {httpRequestException.Message}");
    				}
    
    
    			}
    
    
    		}
    
    		public string AssembleOAuthHeader()
    		{
    			return "Authorization: OAuth " +
    				   "realm=\"yahooapis.com\"," +
    				   "oauth_consumer_key=\"" + consumerKey + "\"," +
    				   "oauth_nonce=\"" + Guid.NewGuid() + "\"," +
    				   "oauth_signature_method=\"PLAINTEXT\"," +
    				   "oauth_timestamp=\"" + ((DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1).Ticks) / (1000 * 10000)) +
    				   "\"," +
    				   "oauth_version=\"1.0\"," +
    				   "oauth_signature=\"" + consumerSecret + "%26\"," +
    				   "oauth_callback=\"oob\"";
    
    		}

    async Task Main()
    {
    	 // Input Value
	     int input = 100;
	
	     // Json Serialize the Input
	     string jsonInput = JsonConvert.SerializeObject(input);
	
	     // Execute Api call Async
         var httpResponseMessage = await MakeApiCall(jsonInput, 
                                           "api/Test","http://localhost:59728/");
	     // Process string[] and Fetch final result
	     var result = await FetchJsonResult<string>(httpResponseMessage);
	
	    // Print Result
	    result.Dump();
    }
    
    private async Task<HttpResponseMessage> MakeApiCall(string jsonInput,
    													string api,
    													string host)
    
    {
    	// Create HttpClient
    	var client = new HttpClient { BaseAddress = new Uri(host) };
    
    	// Assign default header (Json Serialization)
    	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    	// Add String Content
    	var stringContent = new StringContent(jsonInput);
    
    	// Assign Content Type Header
    	stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    
    	// Make an API call and receive HttpResponseMessage
    	HttpResponseMessage responseMessage;
    	
    	responseMessage = await client.PostAsync(api, stringContent);	
    
    	return responseMessage;
    }
    
    private async Task<T> FetchJsonResult<T>(HttpResponseMessage result)
    {
    	// Convert the HttpResponseMessage to Byte[]
    	var resultArray = await result.Content.ReadAsStringAsync();
    
    	// Deserialize the Json string into type using JsonConvert
    	var final = JsonConvert.DeserializeObject<T>(resultArray);
    
    	return final;
    }

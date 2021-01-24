    public static void Main()
    {
    	string API_KEY = "YourApiKey";
    	
    	HttpClient httpClient = new HttpClient();
    	var authHeaderBytes = Encoding.ASCII.GetBytes(API_KEY + ":");
    	httpClient.DefaultRequestHeaders.Authorization = 
    		new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(authHeaderBytes));
    	
    	var requestPayload = new Dictionary<string, string>
    	{
    		{ "name", "John Doe" },
    		{ "address_line1", "123 Main St" },
    		{ "address_city", "San Francisco" },
    		{ "address_state", "CA" },
    		{ "address_zip", "94107" },
    		{ "address_country", "US" }
    	};
    	
    	var encodedRequestForm = new FormUrlEncodedContent(requestPayload);
    	var APIResponse = httpClient.PostAsync("https://api.lob.com/v1/addresses", encodedRequestForm).GetAwaiter().GetResult();
    	var addressString = APIResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    	
    	System.Console.WriteLine(addressString);
    }

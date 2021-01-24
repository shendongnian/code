    public class ClientApi
    {
        public object Get(string url)
    	{
    		using (var client = new HttpClient())
    		{
    			var response = client.GetAsync(url).Result;
    			if (response.IsSuccessStatusCode)
    			{
    				var responseContent = response.Content;
    				return responseContent.ReadAsStringAsync().Result;
    			}
    		}
    
    	}
    }

    public static async Task<ApiCallResult<X>> Post<T, X>(T data, X returnModel, string apiUrl) where X: class
    {
	    var apiCallResult = new ApiCallResult<X> { IsError = true, Message = "No run" };
        try
        {
		    //json string 
    		var jsonString = JsonConvert.SerializeObject(data);
    		using (var client = new HttpClient())
    		{
    			var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
    			var response = await client.PostAsync(apiUrl, httpContent);
    			var jsonResponseString = await response.Content.ReadAsStringAsync();
   
                //fill
                apiCallResult.StatusCode = response.StatusCode;
                apiCallResult.ReasonPhrase = response.ReasonPhrase;
                if (response.IsSuccessStatusCode)
                {
                    //deserialize
                    if (typeof(X).GetGenericTypeDefinition() == typeof(List<>))
                    {
                        // X is a generic list
                        apiCallResult.Response = JsonConvert.DeserializeObject<X>(jsonResponseString);
                    }
                    else
                    {
                        //single object
                        apiCallResult.Message = JsonConvert.DeserializeObject<X>(jsonResponseString).ToString();
                    }
                    apiCallResult.IsError = false;
                }
                else
                {
                    //error response
                    apiCallResult.Message = jsonResponseString;
                }
            }
        }
        catch (Exception ex)
        {
             apiCallResult.IsException = true;
             apiCallResult.Message = ex.Message;
        }
        
        return apiCallResult;
    }

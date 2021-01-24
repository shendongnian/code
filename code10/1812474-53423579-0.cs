    var client = new RestClient("https://serverurl.com");
    var request = new RestRequest(Method.GET);
    
    request.AddHeader("Authorization", "Basic Z3JvdXAxOlByb2otMzI1");
    request.AddHeader("Content-Type", "application/json");
    request.AddHeader("Tenant-Id", "4892");
    
    IRestResponse response = client.Execute(request);
    
    //Resend the request if we get 401
    int numericStatusCode = (int)response.StatusCode;
    if(numericStatusCode == 401) {
    	var redirectedClient = new RestClient(response.ResponseUri.ToString());
    	IRestResponse newResponse = redirectedClient.Execute(request);
    	Console.WriteLine(newResponse.ResponseStatus);
    }

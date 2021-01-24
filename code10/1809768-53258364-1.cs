    using (var client = new HttpClient())
    {
    	client.DefaultRequestHeaders.Accept.Clear();
    	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    	
    	var builder = new UriBuilder("http://localhost:18511/Randezvous.asmx/getUnitPersonels");
    	var query = HttpUtility.ParseQueryString(builder.Query);
    	query["unitNo"] = "0";
    	builder.Query = query.ToString();
    	string url = builder.ToString();
    
    	var result = Task.FromResult(client.GetAsync(url).Result).Result.Content;
    	var resultJson = result.ReadAsStringAsync().Result;
    
    }

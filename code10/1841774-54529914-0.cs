    public async Task<IHttpActionResult> ValidateSesion()
    {
    	var values = new Dictionary<string, string>{
    	  { "productId", "1" },
    	  { "productKey", "Abc6666" },
    	  { "userName", "OPPO" },
      	};
    	var json = JsonConvert.SerializeObject(values, Formatting.Indented);
    
    	var stringContent = new StringContent(json);
    	
    	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    	
    	var response = await client.PostAsync("http://172.116.12.172:8014/iadmin/validate", stringContent);
    	var responseString = await response.Content.ReadAsStringAsync();
    	return Ok(responseString);
    }

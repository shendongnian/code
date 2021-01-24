    [HttpPost]
    public async Task<HttpResponseMessage> Post()
    {
    
    	string result = await Request.Content.ReadAsStringAsync();
    	var resp = new HttpResponseMessage(HttpStatusCode.OK);
    	var model = JsonConvert.DeserializeObject<RootObject>(result);
    	resp.Content = new StringContent(model.resource_url, System.Text.Encoding.UTF8, "application/json");
    	return resp;
    }

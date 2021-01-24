    [HttpGet]
    public async Task<ActionResult> Get()
    {
        response = await client.GetAsync(other_api_url);
        if(response.IsSuccessStatusCode)
        {
            // DO NOT USE `.Result` within async method.
            string result = await response.Content.ReadAsStringAsync();
            dynamic output = JsonConvert.DeserializeObject<dynamic>(result);
    
            statusUrl = output.url_to_check_status;
            bool? result = null;
            while(result == null) result = await CheckIfSuccessfulAsync(statusUrl);
            if (result) return Ok();       
            return NotFound();
        }
    }
    // Does not *need* to be a separate method, it's just for better readability...
    private async Task<bool?> CheckIfSuccessfulAsync(string statusUrl)
    {    
        //make a call to statusUrl check if content is ready
        //get result and parse it
        ...
    
        status = output.status;
    
        if (status == "SUCCESS") return true;
        else if (status == "PENDING") return false;
            
        return null;
    }

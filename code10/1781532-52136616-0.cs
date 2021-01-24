    [HttpPost]
    public async Task<HttpResponseMessage> Index()
    {
        // Get the body (json) as a raw string
        string originalTransaction = await Request.Content.ReadAsStringAsync();
    
        // Wrap the transaction
        var id = Guid.NewGuid();
        var envelope = $"\{ \"Id\": {id}, \"OriginalTransactionData\": {originalTransaction} \}";
    
        // Build a response, so your string is sent back as a json
        var response = this.Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(envelope, Encoding.UTF8, "application/json");
        return response;
    }

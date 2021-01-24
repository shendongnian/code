    [HttpPost]
    public ContentResult Index()
    {
        using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
        {
            // Get the body (json) as a raw string
            var originalTransaction = reader.ReadToEnd();
            
            // Wrap the transaction
            var id = Guid.NewGuid();
            var envelope = $"{{ \"Id\": \"{id}\", \"OriginalTransactionData\": {originalTransaction} }}";
            
            // return json
            return Content(envelope, "application/json", Encoding.UTF8);
        }
    }

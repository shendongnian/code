    [FunctionName("AzureFunction")]
    public static async Task<IActionResult> 
    Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/function")], HttpRequest req, ILogger log)
    {
        MemoryStream outputStream = new MemoryStream();
        StreamWriter writer = new StreamWriter(outputStream);
        JsonWriter jsonWriter = new JsonTextWriter(writer);
    
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName("Property");
        jsonWriter.WriteValue("Value");
        jsonWriter.WriteEndObject();
    
        jsonWriter.Flush(); // Flush the json before returning.
        outputStream.Seek(0, SeekOrigin.Begin);
        return new FileStreamResult(outputStream, "application/json");
    }

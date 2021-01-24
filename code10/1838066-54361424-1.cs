    var client = new HttpClient();
    var queryString = HttpUtility.ParseQueryString(string.Empty);
    
    // Request headers
    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{subscription key}");
    
    var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/facelists/{faceListId}?" + queryString;
    
    HttpResponseMessage response;
    
    // Request body
    byte[] byteData = Encoding.UTF8.GetBytes("{body}");
    
    using (var content = new ByteArrayContent(byteData))
    {
    	content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    	response = await client.PutAsync(uri, content);
        // Get the JSON response.
        string contentString = await response.Content.ReadAsStringAsync();
        // Display the JSON response.
        Console.WriteLine("\nResponse:\n");
        Console.WriteLine(JsonPrettyPrint(contentString));
        Console.WriteLine("\nPress Enter to exit...");
    }

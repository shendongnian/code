     var uri = new Uri(url);
     using (var body = new StringContent(JsonConvert.SerializeObject(data)))
     {
        body.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var request = new HttpRequestMessage
        {
           Version = new Version(1, 0),
           Content = body,
           Method = HttpMethod.Post,
           RequestUri = uri
        };
        try
        {
            using (var response = await _client.SendAsync(request,cancellationToken))
            {
               if (response.IsSuccessStatusCode)
               {
                  //Deal with success response
               }
               else
               {
                  //Deal with non-success response
               }               
            }
        }
        catch(Exception ex)
        {
            //Deal with exception.
        }
     }

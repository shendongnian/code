    var client = new HttpClient();
    var content = new StringContent(authXML);
    content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
    client.BaseAddress = new Uri(authorizationUri);
    var post = client.PostAsync(authorizationUri, content);
    try {
          post.Wait();
      }
      catch (AggregateException e) {
         foreach (Exception ie in e.InnerExceptions)
            Console.WriteLine("{0}: {1}", ie.GetType().Name,
                              ie.Message);
      }
    			
    if (post.Result.IsSuccessStatusCode)
    {
    	// SUCCESS
    	// Do Something
    }
    else
    {
    	// ERROR
    	// Do Something
    }

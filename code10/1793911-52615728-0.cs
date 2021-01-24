    var client = new HttpClient();
    var content = new StringContent(authXML);
    content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
    client.BaseAddress = new Uri(authorizationUri);
    var post = client.PostAsync(authorizationUri, content);
    post.Wait(); // WAIT FOR THE TASK TO COMPLETE
    if (post.IsFaulted)
    	throw post.Exception;
    			
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

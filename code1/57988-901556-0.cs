    HttpClient c = new HttpClient("http://twitter.com/statuses");
    c.TransportSettings.Credentials = 
        new NetworkCredentials(username, password);
    // make a GET request on the resource.
    HttpResponseMessage resp = c.Get("public_timeline.xml");
    // There are also Methods on HttpClient for put, delete, head, etc
    resp.EnsureResponseIsSuccessful(); // throw if not success
    // read resp.Content as XElement
    resp.Content.ReadAsXElement(); 

    private IRestResponse response;
    public IRestResponse POSTAsync(string url) {
     IRestResponse response = null;
    
     client.ExecuteAsync(new RestRequest(url, Method.POST), (r) => {
      if (r.StatusCode == HttpStatusCode.OK) // This is going to a new thread and will be executing later
      response = r;                          // eventually this will be called, but your method did not wait for that completition
     });
    
     return response; // Response will always be null because the Async method is not
                      // finished yet
    }

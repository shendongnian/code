    private IRestResponse response;
    public IRestResponse POSTAsync(string url) {
     IRestResponse response = null;
    
     client.ExecuteAsync(new RestRequest(url, Method.POST), (r) => {
      if (r.StatusCode == HttpStatusCode.OK)
      response = r;
     }); // This is going to a new thread and will be executing later
    
     return response; // Response will always be null because the Async method is not
                      // finished yet
    }

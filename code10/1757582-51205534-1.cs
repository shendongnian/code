    public async List<WbsResponse> GetWbsResults()
        {
            List<WbsRequest> requests = CompileWbsRequests();
            List<Task<WbsResponse>> tasks = new List<Task<WbsResponse>>();
            for (var i = 0; i < requests.Count; i++)
            {
                var task = new Task<WbsResponse>(() => { CallWebService(WbsRequest); });
                tasks.Add(task);
            }
            var responses = await Task.WhenAll(tasks);
    
            var responsesOrdered = responses.OrderBy(r => r.Order)
    
            //do something with results
    
            return results;
        }  
    public List<WbsRequest> CompileWbsRequests()
        {
            //create requests
            foreach(var request in requests)
            {
                request.Order += 1;
            }
        }
     
    
        private WbsResponse CallWebService(WbsRequest request)
        {
            //Call web service
    
            reponse.order = request.order;
            return reponse;
        }

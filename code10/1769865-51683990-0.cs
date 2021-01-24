    public class CorrelatingHandler : HttpClientHandler
     {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.Add("currelationId", Guid.NewGuid());
    
                return base.SendAsync(request, cancellationToken);
            }
     }
    
   
    
    using(var client = new HttpClient(new CorrelatingHandler())){
      .....
    }

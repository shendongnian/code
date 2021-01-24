    public class ValuesController : ApiController
    {
      [Authorize]
      public IHttpActionResult Get()
      {
        var authToken = Request.Headers.Authorization;
        // send authToken with requests to child endpoints
      }
    }

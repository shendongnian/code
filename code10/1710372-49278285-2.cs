     public class TokenTestController : ApiController
        {
            [Authorize]
            public IHttpActionResult Authorize()
            {
                return Ok("Authorized");
            }
    
        }

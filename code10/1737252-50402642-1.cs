    [RoutePrefix("api/Example")]
    public class ExampleController : ApiController
    {
        [HttpGet]
        [Route("Test")]
        public IHttpActionResult Test()
        {
            return Ok();
        }
    }

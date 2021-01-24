    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        [HttpGet]
        [Route("/api")]  // url... /api
        [Route("/api/test")] // url... /api/test
        [Route("testalso")] // url... /api/test/get/testalso
        public string Get()
        {
            return "Alive";
        }
        [HttpGet("/api/echo/{id}")] // url... /api/echo/{id}
        public string Echo(string id)
        {
            return $"Get Echo: {id}";
        }
        [HttpPost("{id}")]  // url... /api/test/postit/{id}
        public string PostIt(string id)
        {
            return $"Thanks for {id}";
        }
    }

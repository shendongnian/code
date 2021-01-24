    [Produces("application/json")]
    [Route("api/MyController")]
    public class MyController : Controller
    {
        [HttpGet]
        [Route("/api/MyNewMethodName")]
        public object MyNewMethodName(string parameter1)
        {
            return "Some test"+parameter1;
        }
        [HttpGet]
        [Route("MyNewMethodName2")]
        public object MyNewMethodName2(string parameter1)
        {
            return "Some test2222222"+parameter1;
        }
    }

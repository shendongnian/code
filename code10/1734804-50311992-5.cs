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
        [Route("SecondMethod")]
        public object SecondMethod(string parameter1)
        {
            return "SecondMethod : "+parameter1;
        }
    }

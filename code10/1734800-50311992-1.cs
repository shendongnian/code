    [Produces("application/json")]
    public class MyController : Controller
    {
        [HttpGet]
        [Route("api/MyNewMethodName")]
        public object MyNewMethodName(string parameter1)
        {
            return "Sample dummy response : "+parameter1;
        }
    }

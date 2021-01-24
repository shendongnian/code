    [Route("api/[controller]")]
    public class MyController : Controller
    {
        [HttpGet]
        public async IEnumerable<object> Get([FromServices] ApplicationContext context,
                                             MyType myMainParam)
        {
            ...
        }
    }

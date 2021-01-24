    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("api/values")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }

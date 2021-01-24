    [Route("api/[controller]")]
    public class TestController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> GetData()
        {
            return new string[] { "value1", "value2" };
        }
    }
    

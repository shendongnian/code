    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly MyShardData _myShardData;
        public TestController(MyShardData myShardData)
        {
             _myShardData = myShardData;
        }
    
        [HttpGet]
        public IActionResult Index()
        {
            return Content(_myShardData.Message);
        }
    
        [HttpPut]
        public IActionResult SetMessage(string pMessage)
        {
            _myShardData.Message = pMessage;
    
            return NoContent();
        }
    }

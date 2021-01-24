    [Produces("application/json")]
    [Route("api/test")] 
    public class TestController : Controller
    {
    
        [HttpGet]
        [EnableQuery]
        public IQueryable<Test> Get()
        {
            return _testService.Query();
        }
    	
        //etc
    }

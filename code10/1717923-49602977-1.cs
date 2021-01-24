    [Route("api/[controller]")]
    public class ValuesController : Controller {
        private readonly ValuesService _valuesService;
    
        public ValuesController() {
            _valuesService = new ValuesService(); 
        }
        //GET api/values
        [HttpGet]
        public IActionResult ReturnValues() {
            return Ok(_valuesService.ReturnValues());
        }
    }

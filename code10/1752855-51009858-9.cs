    [Route("api/[controller]")]
    public class ValuesController : Controller {
        private readonly IHttpClientFactory factory;
        
        public MyController(IHttpClientFactory factory) {
            this.factory = factory;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get() {
            var client = factory.CreateClient("TestClient");
            var result = client.GetStringAsync("api/messages");
            return Ok(result);
        }
    }
    

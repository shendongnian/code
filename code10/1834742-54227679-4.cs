    [Route("api/[controller]")]
    public class ValuesController : Controller {
        private readonly IHttpClientFactory _httpClientFactory;
        public ValuesController(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Get() {
            var client = _httpClientFactory.CreateClient();
            var url = "http://example.com";
            var result = await client.GetStringAsync(url);
            return Ok(result);
        }
    }
    

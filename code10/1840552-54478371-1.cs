     private readonly IHttpClientFactory _httpClientFactory;
            public DataProController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }
            [HttpGet]
            public async Task<ActionResult> Get()
            {            
                var client = _httpClientFactory.CreateClient("github");
                
                client.BaseAddress = new Uri("https://api.github.com/");
                string result = await client.GetStringAsync("/");
                return Ok(result);
            }

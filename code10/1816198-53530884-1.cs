        [Route("api/[controller]/[action]")]
        [ApiController]
        public class HttpClientController : ControllerBase
        {
            private readonly HttpClient _httpClient;
            public HttpClientController(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }
            public async Task CallWebApi()
            {
                string url = @"https://localhost:44342/api/message/post";
                var model = new MessageVM {
                    Id = 1,
                    Name = "Test"
                };
                var response = await _httpClient.PostAsJsonAsync(url, model);
                var result = await response.Content.ReadAsStringAsync();
            }
        }

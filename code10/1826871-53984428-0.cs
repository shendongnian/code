    public class HomeController : Controller
    {
        private readonly HttpClient httpClient;
        public HomeController(
            , IHttpClientFactory httpClientFactory)
        {
            this.httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IActionResult> Index()
        {
            this.httpClient.BaseAddress = new Uri($"{this.Request.Scheme}://{this.Request.Host}");
            var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get,
                "data/some.json"));
            var result = await response.Content.ReadAsStringAsync();
            
            return View();
        }
    }

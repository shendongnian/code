         public class IndexModel : PageModel
        {
        private readonly ApiClient _apiClient;
        public IndexModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task OnGet()
        {
            var result3 = await _apiClient.GetAsync("https://www.baidu.com/");
        }

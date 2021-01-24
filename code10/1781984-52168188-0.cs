    public class ProductsViewComponent : ViewComponent
    {
        private readonly HttpClient _client;
        public ProductsViewComponent(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<IViewComponentResult> InvokeAsync(string date)
        {
           using (var response = await _client.GetAsync($"/"product/get_products/{date}"))
           {
               response.EnsureSuccessStatusCode();
               var products = await response.Content.ReadAsAsync<List<Product>>();
               return View(products);
           }
        }
    }

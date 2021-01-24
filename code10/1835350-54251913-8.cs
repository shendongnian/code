    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;
        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Catalog> GetCatalogItems(int page, int take, 
                                               int? brand, int? type)
        {
            ....
            var responseString = await _httpClient.GetStringAsync(uri);
            ...
        }
    }

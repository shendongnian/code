    public sealed class ProductsService
    {
        public async Task<IEnumerable<Product>> LoadProductsAsync()
        {
            // TODO: to load products from database use your favorite ORM
            // or raw ADO .NET; anyway, you want this to be async
            // since this is I/O bound operation
        }
    }

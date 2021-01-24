    public sealed class MainWindowVm
    {
        private readonly ProductsService productsService;
        private ObservableCollection<ProductVm> products;
        public MainWindowVm()
        {
            // in production apps, services must be injected using DI-containers
            // like Autofac, MEF, NInject, etc
            productsService = new ProductsService();
        }
        public IEnumerable<ProductVm> Products
        {
            get
            {
                if (products == null)
                {
                    // when UI wants to display products,
                    // we create empty collection and initiate async operation;
                    // later, when async operation will be finished,
                    // we will populate collection using values from database
                    products = new ObservableCollection<ProductVm>();
                    var _ = LoadProductsAsync();
                }
                return products;
            }
        }
        private async Task LoadProductsAsync()
        {
            // service returns collection of product models,
            // but we need collection of product view models
            var productModels = await productsService.LoadProductsAsync();
            foreach (var model in productModels)
            {
                products.Add(new ProductVm(model));
            }
        }
    }

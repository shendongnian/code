    public class ProductStockQuantityConverter
    {
        private readonly ProductService productservice = Container.Resolve<ProductService>();
        private readonly IMapper mapper = Container.Resolve<IMapper>();
        public ProductStockQuantityConverter()
        {
        }
    }

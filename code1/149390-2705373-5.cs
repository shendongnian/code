    public class CatalogViewModel : ViewModel<ICatalog>
    {
        public CatalogViewModel(ICatalog catalog)
            : base(catalog)
        {
            Func<ICatalogProduct, ProductViewModel> viewModelFactory = CreateProductViewModel;
            this.Products = ViewModelCollection.Create(catalog.Products, viewModelFactory);
        }
        public ICollection<ProductViewModel> Products
        {
            get;
            private set;
        }
        private ProductViewModel CreateProductViewModel(ICatalogProduct product)
        {
            return new ProductViewModel(product, this);
        }
    }

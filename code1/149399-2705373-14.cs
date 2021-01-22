    public class ProductViewModel : ViewModel<IProduct>
    {
        public ProductViewModel(IProduct product)
            : base(product)
        {
            Func<IProduct, ProductViewModel> productViewModelFactory = CreateProductViewModel;
            Func<IRelease, ReleaseViewModel> releaseViewModelFactory = CreateReleaseViewModel;
            this.Products = ViewModelCollection.Create(product.Products, productViewModelFactory);
            this.Releases = ViewModelCollection.Create(product.Releases, releaseViewModelFactory);
            this.Children = ConcatCollection.Create<object>((ICollection)this.Products, (ICollection)this.Releases);
        }
        public IList<ProductViewModel> Products
        {
            get;
            private set;
        }
        public IList<ReleaseViewModel> Releases
        {
            get;
            private set;
        }
        public IEnumerable<object> Children
        {
            get;
            private set;
        }
        private ProductViewModel CreateProductViewModel(IProduct product)
        {
            return new ProductViewModel(product);
        }
        private ReleaseViewModel CreateReleaseViewModel(IRelease release)
        {
            return new ReleaseViewModel(release);
        }
    }

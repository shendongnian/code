    public class ProductPresenter: Presenter
    {
        #region Declaration
        private readonly IProductRepository _productRepository;
        #endregion
        public ProductPresenter(IProductRepository productRepository)
        {
            #region Initialization
            _productRepository = productRepository;
            #endregion
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        public DelegateCommand AddProductCommand { get; set; }
        public ViewModel()
        {
            _productService = new ProductService();
            _myProduct = new ProductModel();
            AddProductCommand = new DelegateCommand(FillDescription);
        }
        async void FillDescription(object _)
        {
            try
            {
                await Task.Run(() => _myProduct.ProductName = _productService.GetProductName());
            }
            catch(Exception)
            {
                //...
            }
        }
    }

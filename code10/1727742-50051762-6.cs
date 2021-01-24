    public class ViewAViewModel : BindableBase
    {
        private DataTable _productData;
        private IDataFactory _dataFactory;
        public ViewAViewModel(IDataFactory dataFactory)
        {
            _dataFactory = dataFactory;
        }
        public DataTable ProductData
        {
            get { return _productData; }
            set { _productData = value; OnPropertyChanged(); }
        }
        public void Load()
        {
            ProductData = _dataFactory.Create(typeof(FooData));
        }
    }

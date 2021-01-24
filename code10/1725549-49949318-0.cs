	public class OrdersViewModel : ViewModelBase
	{
		private IProductsDataProvider _dataProvider;
		private IEventAggregator _eventAggregator;
		private ObservableCollection<Product> _productsComboBox;
		public ObservableCollection<Product> ProductsComboBox 
		{ 
			get { return _productsComboBox; }
			set { _productsComboBox = value; OnPropertyChanged(); }
		}
		
		public OrdersViewModel(IProductsDataProvider dataProvider, IEventAggregator eventAggregator) 
		{
			_dataProvider = dataProvider;
			_eventAggregator = eventAggregator;
			ComboBoxItems = new ObservableCollection<Product>();
			_eventAggregator.GetEvent<GlobalUIX.ProductCreatedEvent>().Subscribe(OnProductCreatedEventHandler);
		}
		
		public void Initialize() 
		{
			//Logic to load combo box with data from the database
			var products = _dataProvider.GetAllProducts();
			ProductsComboBox.AddRange(products);
		}
		
		private void OnProductCreatedEventHandler(int eventPayloadProductId) 
		{
			var isProductInComboBox = ProductsComboBox.SingleOrDefault(p => p.Id == eventPayloadProductId);
			
			if (isProductInComboBox == null) {		
				var existingProduct = _dataProvider.GetProductById(eventPayloadProductId);
				ProductsComboBox.Add(newProduct);
			}
		}
	}

    public partial class NewForm : Window
    {
        private Dictionary<String, String> _productsComponents;
        public Products
        {
            get { return _productsComponents; }
            set { _productsComponents= value; }
        }
    
        public NewForm()
        {
            Products = new Dictionary<String, String>();
            //Do you're dictionary loading...
            InitializeComponent();
    
            DataContext = this;
    
            ProductCmbBox.ItemsSource = Products;
            ProductCmbBox.SelectedValuePath = "Key";
            ProductCmbBox.DisplayMemberPath = "Value"; //or "Key" if you want...
        }
    }
    
    <ComboBox x:Name="ProductCmbBox" ... />

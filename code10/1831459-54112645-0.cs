    public class DataGridDataSource
    {
        public List<Customer> Customers => Customer.Customers();
    }
    public sealed partial class MainPage : Page
    {
        public DataGridDataSource MyViewModel => new DataGridDataSource();
        public MainPage()
        {
            InitializeComponent();
        }
    }

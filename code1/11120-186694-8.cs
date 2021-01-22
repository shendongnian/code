    public partial class Window1
    {
        public Window1()
        {
            InitializeComponent();
            ObservableCollection<MyCustomer> myCustomers
                = new ObservableCollection<MyCustomer>()
            {
                new MyCustomer(){CustomerName="Paul"},
                new MyCustomer(){CustomerName="John"},
                new MyCustomer(){CustomerName="Mary"}
            };
            ObservableCollection<YourCustomer> yourCustomers
                = new ObservableCollection<YourCustomer>()
            {
                new YourCustomer(){CustomerName="Peter"},
                new YourCustomer(){CustomerName="Chris"},
                new YourCustomer(){CustomerName="Jan"}
            };
            //DataContext = myCustomers;
            DataContext = yourCustomers;
        }
    }

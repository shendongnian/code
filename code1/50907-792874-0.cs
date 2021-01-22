    public Window1()
    {
        InitializeComponent();
        listBox1.ItemsSource = Customer.GetAllCustomers();
    }

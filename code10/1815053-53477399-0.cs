    private DataTable dt;
    public MainWindow()
    {
       InitializeComponent();
       dt=Query();// return datatable from the database
       myComboBox.ItemsSource = dt.AsEnumerable().Select(x => x["Type"].ToString()).ToList();
    }

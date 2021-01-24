    public DisplayUsersWindow(DataTable dataTable)
    {
        InitializeComponent();
        Datas = dataTable;
        ListViewData.ItemsSource = Datas.DefaultView;
    }

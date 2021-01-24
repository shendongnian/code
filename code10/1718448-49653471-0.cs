    ObservableCollection<DisplayTable> list = new ObservableCollection<DisplayTable>();
    public MainWindow()
    {
        InitializeComponent();
        dataGrid.AutoGenerateColumns = true;
        dataGrid.IsReadOnly = false;
        dataGrid.RowHeight = 30;
        dataGrid.ColumnWidth = 100;
        dataGrid.ItemsSource = list;
        dataGrid.CanUserAddRows = true;
    }
    private void btnAddAnalyte_Click(object sender, RoutedEventArgs e)
    {
        DisplayTable d = new DisplayTable();
        foreach (CheckBox item in this.AnalyteLitst.Items)
        {
            if (item.IsChecked == true)
            {
                d.AnalyteId = 1;
            }
        }
        foreach (CheckBox unit in this.UnitsList.Items)
        {
            if (unit.IsChecked == true)
            {
                d.UnitCode = 12;
            }
        }
        list.Add(d);
    }

    DataTable dt = new DataTable();
    DataColumn dc1 = new DataColumn("Value1", typeof(double));
    DataColumn dc2 = new DataColumn("Value2", typeof(double));
    DataColumn dc3 = new DataColumn("Value3", typeof(double));
    DataColumn dc4 = new DataColumn("Value4", typeof(double));
    dt.Columns.Add(dc1);
    dt.Columns.Add(dc2);
    dt.Columns.Add(dc3);
    dt.Columns.Add(dc4);
    DataGrid dg = new DataGrid()
    {
        ItemsSource = dt.DefaultView,
        Background = Brushes.Wheat,
        AlternatingRowBackground = Brushes.AliceBlue,
        VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
        Height = 500,
        Width = 400,
    };
    dt.Rows.Add(1.5, 2.5, 3.5);
    dt.Rows.Add(1.5, 2.5, null);
    dt.Rows.Add(1.5, 2.5, 3.5, 4.5);
    MyCanvas.Children.Add(dg);  // A canvas in the XAML
    Canvas.SetTop(10,dg);
    Canvas.SetLeft(10,dg);

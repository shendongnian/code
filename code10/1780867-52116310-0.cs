    DataGrid dg = new DataGrid();
    dg.HorizontalAlignment = HorizontalAlignment.Center;
    dg.VerticalAlignment = VerticalAlignment.Top;
    dg.AutoGenerateColumns = true;
    getData gd = new getData();
    UserData[] userData = gd.getUserRecord();
    dg.ItemsSource = userData;
    FrameworkElementFactory sp = new FrameworkElementFactory(typeof(StackPanel));
    sp.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
    FrameworkElementFactory delete = new FrameworkElementFactory(typeof(Button));
    delete.AddHandler(Button.ClickEvent, new RoutedEventHandler((s, e) => { MessageBox.Show("deleted click!"); }));
    delete.SetValue(ContentControl.ContentProperty, "Delete");
    FrameworkElementFactory edit = new FrameworkElementFactory(typeof(System.Windows.Controls.Button));
    edit.AddHandler(Button.ClickEvent, new RoutedEventHandler((s, e) => { MessageBox.Show("edited click!"); }));
    edit.SetValue(ContentControl.ContentProperty, "Edit");
    edit.SetValue(FrameworkElement.MarginProperty, new Thickness(5, 0, 0, 0));
    sp.AppendChild(delete);
    sp.AppendChild(edit);
    DataGridTemplateColumn dataGridTemplateColumn = new DataGridTemplateColumn()
    {
        Header = "new...",
        CellTemplate = new DataTemplate { VisualTree = sp }
    };
    dg.Columns.Add(dataGridTemplateColumn);

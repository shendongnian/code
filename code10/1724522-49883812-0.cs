    private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        var cb = new ComboBox();
        foreach (DataColumn test in (DataContext as EnterValueDialogViewModel).displayTable.Columns)
            Console.Out.WriteLine(test);
        cb.ItemsSource = (DataContext as EnterValueDialogViewModel).displayTable.Columns;
        cbotest.DisplayMemberPath = "Column1";
        cbotest.SelectedValuePath = "Column2";
        e.Column.Header = cb;
    }   

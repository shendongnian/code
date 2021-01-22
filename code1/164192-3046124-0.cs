    private void dg_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        e.Row.MouseRightButtonDown += new MouseButtonEventHandler(Row_MouseRightButtonDown);
    }
    void Row_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        dg.SelectedItem = ((sender) as DataGridRow).DataContext;
    } 

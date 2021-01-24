    async void dataGrid_MouseDoubleClick(object o, MouseButtonEventArgs e)
    {
        var dg = (DataGrid)o;
        if (dg.SelectedItem != null)
        {
            await MyAsyncMethod(((MyCustomType)dg.SelectedItem)item.Id);
        }
    }

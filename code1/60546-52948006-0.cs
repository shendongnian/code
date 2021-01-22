    private void DataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
    {
        string content = (e.EditingEventArgs.Source as TextBlock).Text;
        if (!(String.IsNullOrEmpty(content)))
            e.Cancel = true;
    }

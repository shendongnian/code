    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyType == typeof(DateTime))
        {
            e.Column = new DataGridTextColumn()
            {
                Binding = new Binding(e.PropertyName) { StringFormat = "yyyy-MM-dd" }
            };
        }
    }

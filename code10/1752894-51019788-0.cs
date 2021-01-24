    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "VALUE":
                e.Column = new DataGridTextColumn
                {
                    Header = e.PropertyName,
                    Binding = new Binding(e.PropertyName)
                    {
                        StringFormat = "N2"
                    }
                };
                break;
            case "DATE":
                e.Column = new DataGridTextColumn
                {
                    Header = e.PropertyName,
                    Binding = new Binding(e.PropertyName)
                    {
                        StringFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern
                    }
                };
                break;
        }
    }

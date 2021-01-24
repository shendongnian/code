    private void dataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "FirstColumnProp")
        {
            e.Column.IsReadOnly = true;
        }
        else if ...
    }

    const int n = 20;
    DataTable table = new DataTable();
    for (int i = 0; i<n; i++)
    {
        string columnName = "Column-" + i;
        DataGridCombo.Columns.Add(CreateCustomComboBoxDataSouce(columnName));
        table.Columns.Add(columnName, typeof(string));
    }
    table.Rows.Add(new object[n]);
    //select some values...
    table.Rows[0][1] = "LEInt";
    table.Rows[0][5] = "String";
    DataGridCombo.DataContext = table;

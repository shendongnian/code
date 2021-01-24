    foreach (DataColumn dC in DT.Columns)
    {
        var col = new DataGridTextColumn();
        col.Header = dC.ColumnName;
        col.Binding = new Binding(dC.ColumnName); //<--
        gainLoss.dataGrid.Columns.Add(col);
    }

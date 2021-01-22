    grid.BeginInit();
    grid.Items.Clear();
    foreach (var db_row in query.Rows)
    {
        var row = new DataGridRow();
        row.Item = db_row;
        grid.Items.Add(row);
    }
    grid.EndInit();

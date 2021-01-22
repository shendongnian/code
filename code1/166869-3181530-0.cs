    int MAX_ROWS = 10;
    int MAX_CELLS = 10;
    dataGridView1.ColumnCount = MAX_CELLS;
    int currentRowIndex = dataGridView1.Rows.Add(MAX_ROWS);
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        foreach (DataGridViewCell cell in row.Cells)
        {
            cell.ValueType = typeof(String);
            cell.Value = "This is the: " + cell.OwningColumn.Index.ToString() + 
                " " + cell.OwningRow.Index.ToString() + " cell";
        }
    }

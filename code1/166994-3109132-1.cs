    DataTable dt = new DataTable();
    foreach(DataGridViewColumn col in dgv.Columns)
    {
       dt.Columns.Add(col.Name);    
    }
    
    foreach(DataGridViewRow row in dgv.Rows)
    {
        DataRow dRow = dt.NewRow();
        foreach(DataGridViewCell cell in row.Cells)
        {
            dRow[cell.ColumnIndex] = cell.Value;
        }
        dt.Rows.Add(dRow);
    }

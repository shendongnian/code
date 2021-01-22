    object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];
    for (int r = 0; r < dt.Rows.Count; r++)
    {
        DataRow dr = dt.Rows[r];
        for (int c = 0; c < dt.Columns.Count; c++)
        {
            arr[r, c] = dr[c];
        }
    }
    Excel.Range c1 = (Excel.Range)wsh.Cells[topRow, 1];
    Excel.Range c2 = (Excel.Range)wsh.Cells[topRow + dt.Rows.Count - 1, dt.Columns.Count];
    Excel.Range range = wsh.get_Range(c1, c2);
    range.Value = arr;

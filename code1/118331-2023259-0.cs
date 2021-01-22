    int rowscount = gv.Rows.Count;
    int columnscount = gv.Columns.Count;
    for (int i = 0; i < rowscount; i++)
    {
        row = empTable.NewRow();
        for (int j = 1; j < columnscount; j++)
        {
            // Referencing the column in the new row by number, starting from 0.
            row[j - 1] = gv.Rows[i][j].Tostring();
        }
    }

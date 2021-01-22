    int rowscount = gv.Rows.Count;
    int columnscount = gv.Columns.Count;
    for (int i = 0; i < rowscount; i++)
    {
        // Create the row outside the inner loop, only want a new table row for each GridView row
        DataRow row = empTable.NewRow();
        for (int j = 1; j < columnscount; j++)
        {
            // Referencing the column in the new row by number, starting from 0.
            row[j - 1] = gv.Rows[i][j].Tostring();
        }
        MynewDatatable.Rows.Add(row);
    }

    // assumes stringdata[row, col] is your 2D string array
    DataTable dt = new DataTable();
    // assumes first row contains column names:
    for (int col = 0; col < stringdata.GetLength(1); col++)
    {
        dt.Columns.Add(stringdata[0, col]);
    }
    // load data from string array to data table:
    for (rowindex = 1; rowindex < stringdata.GetLength(0); rowindex++)
    {
        DataRow row = dt.NewRow();
        for (int col = 0; col < stringdata.GetLength(1); col++)
        {
            row[col] = stringdata[rowindex, col];
        }
        dt.Rows.Add(row);
    }
    // sort by third column:
    DataRow[] sortedrows = dt.Select("", "3");
    // sort by column name, descending:
    sortedrows = dt.Select("", "COLUMN3 DESC");

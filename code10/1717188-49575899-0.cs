    object[,] sheetData = range.Value2;
    DataTable table = new DataTable();
    //Add columns
    for (int i = 1; i < sheetData.GetLength(1) + 1; i++)
    {
        DataColumn column = new DataColumn("Column-" + i, typeof(string));
        table.Columns.Add(column);
    }
    //Add all rows and data within each row. 
    for (int i =  1; i < sheetData.GetLength(0) + 1; i++)
    {
        DataRow row = table.NewRow();
        for (int j = 1; j < sheetData.GetLength(1) + 1; j++)
            row[j - 1] = sheetData[i, j];
        table.Rows.Add(row);
    }

    for (int i = 2; i < rowCount; i++)
    {
        for (int j = 1; j < columnCount; j++)
        {
            worksheet.Cells[i, j].Value2 = enrollmentDataGrid.Columns[j].GetCellContent(enrollmentDataGrid.Items[i]);
        }
     }

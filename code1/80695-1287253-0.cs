     xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    //new code here
    for(int i=0; i<dt.Columns.Count; i++)
    {
      xlWorkSheet.Cells[0,i] = dt.Columns[i].ColumnName;
    }
            
    for (i = 0; i <= dt.Rows.Count - 1; i++)
    {
        for (j = 0; j <= dt.Columns.Count - 1; j++)
        {
             data = dt.Rows[i].ItemArray[j].ToString();
             xlWorkSheet.Cells[i + 2, j + 1] = data;
        }
    }

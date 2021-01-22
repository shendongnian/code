      Excel.Range selectedRange = (Excel.Range)myExcelApp.Selection;
    
      selectedRange.Columns.AutoFit();
    
      foreach (Excel.Range column in selectedRange.Columns)
      {
          column.ColumnWidth = (double)column.ColumnWidth + 5;
      }

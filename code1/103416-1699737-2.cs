      using Excel;
      ...
          Excel.ApplicationClass xl = new Excel.Application();
          xl.Visible = false;
          xl.UserControl = false;
          Excel.Workbook theWorkbook = xl.Workbooks.Open(
             fileName, 0, true, 5,
              "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false,
              0, true); 
         Excel.Sheets sheets = theWorkbook.Worksheets;
         Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
         System.Array myvalues;
         Excel.Range range = worksheet.get_Range("A1", "E1".ToString());
         myvalues = (System.Array)range.Cells.Value;

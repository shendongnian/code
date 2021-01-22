        private Dictionary<int,string> GetExcelSheetNames(string fileName)
        {
         Excel.Application _excel = null;
         Excel.Workbook _workBook = null;
         Dictionary<int,string> excelSheets = new Dictionary<int,string>();
         try
         {
          object missing = Type.Missing;
          object readOnly = true;
    
      Excel.XlFileFormat.xlWorkbookNormal
      _excel = new Excel.ApplicationClass();
      _excel.Visible = false;
      _workBook = _excel.Workbooks.Open(fileName, 0, readOnly, 5, missing,
         missing, true, Excel.XlPlatform.xlWindows, "\\t", false, false, 0, true, true, missing);
      if (_workBook != null)
      {
       
                       int index = 0; 
    
       foreach (Excel.Worksheet sheet in _workBook.Sheets)
       {
        // Can get sheet names in order they are in workbook
        excelSheets.Add(++index, sheet.Name);
       }
      }
     }
     catch (Exception e)
     {
      return null;
     }
     finally
     {
      if (_excel != null)
      {
    
       if (_workBook != null)
       {
        _workBook.Close(false, Type.Missing, Type.Missing);
       }
       _excel.Application.Quit();
      }
      _excel = null;
      _workBook = null;
     }
        return excelSheets;
        }

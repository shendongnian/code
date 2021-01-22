    string MOVE_DOWNLOADED(string FILENAME)
    {
      string Path = FILENAME;
      Microsoft.Office.Interop.Excel.ApplicationClass app = new Microsoft.Office.Interop.Excel.ApplicationClass();           
      Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(Path,
        0,
        true,
        5,
        "",
        "",
        true,
        Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
        "\t",
        false,
        false,
        0,
        true,
        1,
        0);
    
      string retval = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "_tmp_" + ".xlsx";
    
      try
      {
        workBook.SaveAs(retval, 
          Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel9795, 
          null, 
          null, 
          false, 
          false, 
          Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, 
          false, 
          false,
          null,
          null,
          null);
      }
      catch (Exception E)
      {
        MessageBox.Show(E.Message);
      }
    
      workBook.Close(null, null, null);
      System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
      workBook = null;
      GC.Collect(); // force final cleanup!
    
      return retval;    
    }

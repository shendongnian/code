    public static void SaveAs()
    {
        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
        Microsoft.Office.Interop.Excel.Workbook wbWorkbook = app.Workbooks.Add(Type.Missing);
        Microsoft.Office.Interop.Excel.Sheets wsSheet = wbWorkbook.Worksheets;
        Microsoft.Office.Interop.Excel.Worksheet CurSheet = (Microsoft.Office.Interop.Excel.Worksheet)wsSheet[1];
        Microsoft.Office.Interop.Excel.Range thisCell = (Microsoft.Office.Interop.Excel.Range)CurSheet.Cells[1, 1];
    
        thisCell.Value2 = "This is a test.";
    
        wbWorkbook.SaveAs(@"c:\one.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        wbWorkbook.SaveAs(@"c:\two.csv", Microsoft.Office.Interop.Excel.XlFileFormat.xlCSVWindows, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    
        wbWorkbook.Close(false, "", true);
    }

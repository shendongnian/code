    public void runTemplate(string templateName, string sourceFile, string destinationFile, string ITPath, string date)
    {
        string sDate = date;
        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
        ExcelApp.DisplayAlerts = false;
        object misValue = System.Reflection.Missing.Value;
        ExcelApp.Visible = false;
        Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook = ExcelApp.Workbooks.Open(sourceFile);
        ExcelApp.Run("DoTheImport", sDate);
        ExcelWorkBook.SaveCopyAs(destinationFile);
        ExcelWorkBook.SaveCopyAs(ITPath);
        ExcelWorkBook.Close(false, misValue, misValue);
        ExcelApp.Quit();
        if (ExcelWorkBook != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelWorkBook); }
        if (ExcelApp != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelApp); }
    }

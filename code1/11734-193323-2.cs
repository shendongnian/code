    private void AddWorksheetToExcelWorkbook(string fullFilename,string worksheetName)
    {
        Microsoft.Office.Interop.Excel.Application xlApp = null;
        Workbook xlWorkbook = null;
        Sheets xlSheets = null;
        Worksheet xlNewSheet = null;
        try {
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
                return;
            // Uncomment the line below if you want to see what's happening in Excel
            // xlApp.Visible = true;
            xlWorkbook = xlApp.Workbooks.Open(fullFilename, 0, false, 5, "", "",
                    false, XlPlatform.xlWindows, "",
                    true, false, 0, true, false, false);
            xlSheets = xlWorkbook.Sheets as Sheets;
            // The first argument below inserts the new worksheet as the first one
            xlNewSheet = (Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
            xlNewSheet.Name = worksheetName;
            xlWorkbook.Save();
            xlWorkbook.Close(Type.Missing,Type.Missing,Type.Missing);
            xlApp.Quit();
        }
        finally {
            Marshal.ReleaseComObject(xlNewSheet);
            Marshal.ReleaseComObject(xlSheets);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);
            xlApp = null;
        }
    }

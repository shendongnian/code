    void PrintMyExcelFile()
    {
        Excel.Application excelApp = new Excel.Application();
    
        // Open the Workbook:
        Excel.Workbook wb = excelApp.Workbooks.Open(
            @"C:\My Documents\Book1.xls",
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
            Type.Missing, Type.Missing,Type.Missing,Type.Missing);
    
        // Get the first worksheet.
        // (Excel uses base 1 indexing, not base 0.)
        Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
        
        // Print out 1 copy to the default printer:
        ws.PrintOut(
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
            Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    
        // Cleanup:
        GC.Collect();
        GC.WaitForPendingFinalizers();
    
        Marshal.FinalReleaseComObject(ws);
    
        wb.Close(false, Type.Missing, Type.Missing);
        Marshal.FinalReleaseComObject(wb);
    
        excelApp.Quit();
        Marshal.FinalReleaseComObject(excelApp);
    }

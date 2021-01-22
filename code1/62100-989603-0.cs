    void AutomateExcelExample()
    {
        // -------------------------------------------------------
        Excel.Application excelApp = new Excel.Application();
        excelApp.Visible = true;
    
        Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
        Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
        Excel.Range range = worksheet.get_Range("A1", Type.Missing);
    
        range.set_Value(Type.Missing, "Hello World");
    
        // Cleanup:
        GC.Collect();
        GC.WaitForPendingFinalizers();
    
        Marshal.FinalReleaseComObject(range);
        Marshal.FinalReleaseComObject(worksheet);
    
        workbook.Close(false, Type.Missing, Type.Missing);
        Marshal.FinalReleaseComObject(workbook);
    
        excelApp.Quit();
        Marshal.FinalReleaseComObject(excelApp);
    }

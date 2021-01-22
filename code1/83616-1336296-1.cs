    void AutomateExcel()
    {
        Excel.Application excelApp = new Excel.Application();
        excelApp.Visible = true;
    
        Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
        workbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        workbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
        Excel.Range rangeToHoldHyperlink = worksheet.get_Range("A1", Type.Missing);
        string hyperlinkTargetAddress = "Sheet2!A1";
    
        worksheet.Hyperlinks.Add(
            rangeToHoldHyperlink,
            string.Empty,
            hyperlinkTargetAddress,
            "Screen Tip Text",
            "Hyperlink Title");
    
        MessageBox.Show("Ready to clean up?");
    
       // Cleanup:
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    
        Marshal.FinalReleaseComObject(range);
    
        Marshal.FinalReleaseComObject(worksheet);
    
        workbook.Close(false, Type.Missing, Type.Missing);
        Marshal.FinalReleaseComObject(workbook);
    
        excelApp.Quit();
        Marshal.FinalReleaseComObject(excelApp);
    }

    Marshal.FinalReleaseComObject(range);    
    Marshal.FinalReleaseComObject(worksheet);    
    workbook.Close(false, Type.Missing, Type.Missing);    
    Marshal.FinalReleaseComObject(workbook);    
    excelApp.Quit();    
    Marshal.FinalReleaseComObject(excelApp);
    
    // move deterministic call to garbage collector to AFTER release
    // of all COM objects.
    GC.Collect();    
    GC.WaitForPendingFinalizers();
    
    GC.Collect();

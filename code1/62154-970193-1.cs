    Microsoft.Office.Interop.Excel.Application _app = 
                                  new Microsoft.Office.Interop.Excel.Application();
    
    try {
        Workbook wbook = _app.Workbooks.Open(excelFile,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    } catch (COMException ex) {
        //The file can't be opened in Excel
    } finally {
        //close the workbook and release the resources (GC.Collect() et al as usual)
    }
    //The file can be opened in Excel if there wasn't a caught exception.
    //You can wrap the above in a loop to test more than once as per the other answer

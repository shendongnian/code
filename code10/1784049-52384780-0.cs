    var app = new Microsoft.Office.Interop.Excel.Application();
    var workbook = app.Workbooks.Open(htmlFileName);
    if (File.Exists(excelFileName))
    {
        File.Delete(excelFileName);
    }
    workbook.SaveAs(
        excelFileName,
        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault,
        Type.Missing, Type.Missing,  
        false, false,
        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    workbook.Close();
    app.Quit();
    app = null;
    workbook = null;
    using (var stream = File.Open(excelFileName, FileMode.Open, FileAccess.Read))
    {
        var reader = ExcelReaderFactory.CreateReader(stream);
        // ...
    }

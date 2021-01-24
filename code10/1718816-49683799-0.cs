    using Excelx = Microsoft.Office.Interop.Excel;
    public void DeleteRows(string workbookPath)
    {
        // New Excel Application 
        Excelx.Application excelApp = new Excelx.Application();
        //Open WorkBook 
        Excelx.Workbook excelWorkbook = excelApp.Workbooks.Open(workbookPath,
                0, false, 5, "", "", false, Excelx.XlPlatform.xlWindows, "",
                true, false, 0, true, false, false);
        Excelx.Sheets excelSheets = excelWorkbook.Worksheets;
        string currentSheet = "Sheet1";
        Excelx.Worksheet excelWorksheet = (Excelx.Worksheet)excelSheets.get_Item(currentSheet);
        Excelx.Range excelCell = (Excelx.Range)excelWorksheet.get_Range("A1", "A1");
        Excelx.Range row = excelCell.EntireRow;
        row.Delete(Excelx.XlDirection.xlUp);
        // This should be all you need:
        excelWorkbook.Save();
        excelWorkbook.Close();
    }

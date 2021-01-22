    static void CreateSimpleWorkbook()
    {
        // Create a new workbook.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
        SpreadsheetGear.IRange cells = worksheet.Cells;
        // Set the worksheet name.
        worksheet.Name = "2005 Sales";
        // Load column titles and center.
        cells["B1"].Formula = "North";
        cells["C1"].Formula = "South";
        cells["D1"].Formula = "East";
        cells["E1"].Formula = "West";
        cells["B1:E1"].HorizontalAlignment = SpreadsheetGear.HAlign.Center;
        // Load row titles using multiple cell text reference and iteration.
        int quarter = 1;
        foreach (SpreadsheetGear.IRange cell in cells["A2:A5"])
            cell.Formula = "Q" + quarter++;
        // Load random data and format as $ using a multiple cell range.
        SpreadsheetGear.IRange body = cells[1, 1, 4, 4];
        body.Formula = "=RAND() * 10000";
        body.NumberFormat = "$#,##0_);($#,##0)";
        // Save as xls to Disk (can also open / save from / to streams and memory)
        workbook.SaveAs(@"C:\tmp\SimpleWorkbook.xls", SpreadsheetGear.FileFormat.Excel8);
        // Save as xlsx to Disk.
        workbook.SaveAs(@"C:\tmp\SimpleWorkbook.xlsx", SpreadsheetGear.FileFormat.OpenXMLWorkbook);
    }

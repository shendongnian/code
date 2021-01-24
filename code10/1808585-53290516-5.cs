    String pathToYourExcelFile = @"C:\Folder\ExcelFile.xlsx";
    using (SpreadsheetDocument document = SpreadsheetDocument.Open(pathToYourExcelFile, true))
    {
        WorkbookPart workbook =  document.WorkbookPart;
        
        // Loop over all worksheets.
        IEnumerable<WorksheetPart> worksheets = document.WorkbookPart.WorksheetParts;
        foreach (WorksheetPart worksheet in worksheets)
        {
            // Loop over all rows.
            IEnumerable<Row> rows = worksheet.Worksheet.GetFirstChild<SheetData>().Elements<Row>();   
            foreach (Row row in rows) 
            {
                // Loop over all cells.
                foreach (Cell cell in row.Elements<Cell>())
                {
                    // Loop over all cell values.
                    foreach (CellValue cellValue in cell.Elements<CellValue>())
                    {
                        // Apply content formatting as in code above ...
                    }
                }
            }
        }
    }

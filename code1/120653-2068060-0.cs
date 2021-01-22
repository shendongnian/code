            IWorkbook workbook = Factory.GetWorkbook();
            IRange cells = workbook.Worksheets[0].Cells;
            // Format column A as text.
            cells["A:A"].NumberFormat = "@";
            // Set A2 to text with a leading '0'.
            cells["A2"].Value = "01234567890123456789";
            // Format column C as text (SpreadsheetGear uses 0 based indexes - Excel uses 1 based indexes).
            cells[0, 2].EntireColumn.NumberFormat = "@";
            // Set C3 to text with a leading '0'.
            cells[2, 2].Value = "01234567890123456789";
            workbook.SaveAs(@"c:\tmp\TextFormat.xlsx", FileFormat.OpenXMLWorkbook);

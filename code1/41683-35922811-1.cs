        /// <summary>
        /// Got code from: https://msdn.microsoft.com/en-us/library/office/gg575571.aspx
        /// </summary>
        [Test]
        public void WriteOutExcelFile()
        {
            var fileName = "ExcelFiles\\File_With_Many_Tabs.xlsx";
            var sheetName = "Submission Form"; // Existing tab name.
            using (var document = SpreadsheetDocument.Open(fileName, isEditable: false))
            {
                var workbookPart = document.WorkbookPart;
                var sheet = workbookPart.Workbook.Descendants<Sheet>().FirstOrDefault(s => s.Name == sheetName);
                var worksheetPart = (WorksheetPart)(workbookPart.GetPartById(sheet.Id));
                var sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                foreach (var row in sheetData.Elements<Row>())
                {
                    foreach (var cell in row.Elements<Cell>())
                    {
                        Console.Write("|" + GetCellValue(cell, workbookPart));
                    }
                    Console.Write("\n");
                }
            }
        }
        /// <summary>
        /// Got code from: https://msdn.microsoft.com/en-us/library/office/hh298534.aspx
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="workbookPart"></param>
        /// <returns></returns>
        private string GetCellValue(Cell cell, WorkbookPart workbookPart)
        {
            if (cell == null)
            {
                return null;
            }
            
            var value = cell.CellFormula != null
                ? cell.CellValue.InnerText 
                : cell.InnerText.Trim();
            // If the cell represents an integer number, you are done. 
            // For dates, this code returns the serialized value that 
            // represents the date. The code handles strings and 
            // Booleans individually. For shared strings, the code 
            // looks up the corresponding value in the shared string 
            // table. For Booleans, the code converts the value into 
            // the words TRUE or FALSE.
            if (cell.DataType == null)
            {
                return value;
            }
            switch (cell.DataType.Value)
            {
                case CellValues.SharedString:
                    // For shared strings, look up the value in the
                    // shared strings table.
                    var stringTable =
                        workbookPart.GetPartsOfType<SharedStringTablePart>()
                            .FirstOrDefault();
                    // If the shared string table is missing, something 
                    // is wrong. Return the index that is in
                    // the cell. Otherwise, look up the correct text in 
                    // the table.
                    if (stringTable != null)
                    {
                        value =
                            stringTable.SharedStringTable
                                .ElementAt(int.Parse(value)).InnerText;
                    }
                    break;
                case CellValues.Boolean:
                    switch (value)
                    {
                        case "0":
                            value = "FALSE";
                            break;
                        default:
                            value = "TRUE";
                            break;
                    }
                    break;
            }
            return value;
        }

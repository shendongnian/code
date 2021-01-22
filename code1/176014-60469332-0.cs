    using System.Data;
    using System.Linq;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    
    namespace Core_Excel.Utilities
    {
        static class ExcelUtility
        {
            public static DataTable Read(string path)
            {
                var dt = new DataTable();
    
                using (var ssDoc = SpreadsheetDocument.Open(path, false))
                {
                    var sheets = ssDoc.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                    var relationshipId = sheets.First().Id.Value;
                    var worksheetPart = (WorksheetPart) ssDoc.WorkbookPart.GetPartById(relationshipId);
                    var workSheet = worksheetPart.Worksheet;
                    var sheetData = workSheet.GetFirstChild<SheetData>();
                    var rows = sheetData.Descendants<Row>().ToList();
    
                    foreach (var row in rows) //this will also include your header row...
                    {
                        var tempRow = dt.NewRow();
    
                        var colCount = row.Descendants<Cell>().Count();
                        foreach (var cell in row.Descendants<Cell>())
                        {
                            var index = GetIndex(cell.CellReference);
    
                            // Add Columns
                            for (var i = dt.Columns.Count; i <= index; i++)
                                dt.Columns.Add();
    
                            tempRow[index] = GetCellValue(ssDoc, cell);
                        }
    
                        dt.Rows.Add(tempRow);
                    }
                }
    
                var m = dt.Rows[0][9];
    
                return dt;
            }
    
            private static string GetCellValue(SpreadsheetDocument document, Cell cell)
            {
                var stringTablePart = document.WorkbookPart.SharedStringTablePart;
                var value = cell.CellValue.InnerXml;
    
                if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                    return stringTablePart.SharedStringTable.ChildElements[int.Parse(value)].InnerText;
    
                return value;
            }
    
            public static int GetIndex(string name)
            {
                if (string.IsNullOrWhiteSpace(name))
                    return -1;
    
                int index = 0;
                foreach (var ch in name)
                {
                    if (char.IsLetter(ch))
                    {
                        int value = ch - 'A' + 1;
                        index = value + index * 26;
                    }
                    else
                        break;
                }
    
                return index - 1;
            }
        }
    }

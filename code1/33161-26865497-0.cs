    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using System.Xml;
    using System.IO;
    using System.Diagnostics;
    namespace Application.Model{
    public class TempCode
    {
        public TempCode()
        {
            UpdateCell("E:/Visual Studio Code/Book1.xlsx", "120", 1, "A");
            UpdateCell("E:/Visual Studio Code/Book1.xlsx", "220", 2, "B");
            UpdateCell("E:/Visual Studio Code/Book1.xlsx", "320", 3, "C");
            UpdateCell("E:/Visual Studio Code/Book1.xlsx", "420", 4, "D");
            UpdateCell("E:/Visual Studio Code/Book1.xlsx", "520", 5, "E");
            ProcessStartInfo startInfo = new ProcessStartInfo("E:/Visual Studio Code/Book1.xlsx");
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            Process.Start(startInfo);
           
            
            
        }
        public static void UpdateCell(string docName, string text,uint rowIndex, string columnName){
            // Open the document for editing.
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
            {
                WorksheetPart worksheetPart = GetWorksheetPartByName(spreadSheet, "Sheet2");
                if (worksheetPart != null)
                {
                    Cell cell = GetCell(worksheetPart.Worksheet, columnName, rowIndex);
                    cell.CellValue = new CellValue(text);
                    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                    // Save the worksheet.
                    worksheetPart.Worksheet.Save();
                }
            }
        }
        private static WorksheetPart GetWorksheetPartByName(SpreadsheetDocument document, string sheetName){
            IEnumerable<Sheet> sheets =document.WorkbookPart.Workbook.GetFirstChild<Sheets>().
                            Elements<Sheet>().Where(s => s.Name == sheetName);
            if (sheets.Count() == 0){
                return null;
            }
            string relationshipId = sheets.First().Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(relationshipId);
            return worksheetPart;
        }
     
        private static Cell GetCell(Worksheet worksheet, string columnName, uint rowIndex)
        {
            Row row;
            string cellReference = columnName + rowIndex;
            if (worksheet.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
                row = worksheet.GetFirstChild<SheetData>().Elements<Row>().Where(r => r.RowIndex == rowIndex).FirstOrDefault();
            else{
                row = new Row() { RowIndex = rowIndex };
                worksheet.Append(row);
            }
            if (row == null)
                return null;
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).Count() > 0) {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else{
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>()){
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0){
                        refCell = cell;
                        break;
                    }
                }
                Cell newCell = new Cell() {
                    CellReference = cellReference, 
                    StyleIndex = (UInt32Value)1U
                };
                row.InsertBefore(newCell, refCell);
                worksheet.Save();
                return newCell;
            }
        }
    }
}

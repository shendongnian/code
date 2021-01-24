    public static class OpenXMLUtilities
    {
        public static void UpdateCell(SpreadsheetDocument spreadSheet, string sheetName, DataAccess.Domain.CellType cellType, string value, uint rowIndex, string columnName)
        {
            WorksheetPart worksheetPart = GetWorksheetPartByName(spreadSheet, sheetName);
            if (worksheetPart != null)
            {
                Cell cell = GetCell(worksheetPart.Worksheet, columnName, rowIndex);
                cell.CellValue = new CellValue(value);
                switch (cellType)
                {
                    case DataAccess.Domain.CellType.BidLocation:
                    case DataAccess.Domain.CellType.Constant:
                    case DataAccess.Domain.CellType.Email:
                    case DataAccess.Domain.CellType.General:
                    case DataAccess.Domain.CellType.Industry:
                    case DataAccess.Domain.CellType.Name:
                    case DataAccess.Domain.CellType.ProposalNumber:
                    case DataAccess.Domain.CellType.Department:
                    case DataAccess.Domain.CellType.Money:
                    case DataAccess.Domain.CellType.Phone:
                        cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        break;
                    case DataAccess.Domain.CellType.Date:
                        cell.DataType = new EnumValue<CellValues>(CellValues.Date);
                        break;
                    case DataAccess.Domain.CellType.Float:
                    case DataAccess.Domain.CellType.Integer:
                        cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                        break;
                    case DataAccess.Domain.CellType.YesNoOrBlank:
                    case DataAccess.Domain.CellType.YesOrNo:
                        cell.DataType = new EnumValue<CellValues>(CellValues.Boolean);
                        break;
                }
                worksheetPart.Worksheet.Save();
            }
        }
        public static WorksheetPart GetWorksheetPartByName(SpreadsheetDocument document, string sheetName)
        {
            IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(s => s.Name == sheetName);
            if (sheets.Count() == 0)
            {
                // The specified worksheet does not exist.
                return null;
            }
            string relationshipId = sheets.First().Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(relationshipId);
            return worksheetPart;
        }
        private static Cell GetCell(Worksheet worksheet, string columnName, uint rowIndex)
        {
            Row row = GetRow(worksheet, rowIndex);
            if (row == null)
            {
                return null;
            }
            return row.Elements<Cell>().Where(c => string.Compare(c.CellReference.Value, columnName + rowIndex, true) == 0).First();
        }
        private static Row GetRow(Worksheet worksheet, uint rowIndex)
        {
            return worksheet.GetFirstChild<SheetData>().Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
        }
    }

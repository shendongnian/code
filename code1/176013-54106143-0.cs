    public static class ExcelHelper
            {
                //To get the value of the cell, even it's empty. Unable to use loop by index
                private static string GetCellValue(WorkbookPart wbPart, List<Cell> theCells, string cellColumnReference)
                {
                    Cell theCell = null;
                    string value = "";
                    foreach (Cell cell in theCells)
                    {
                        if (cell.CellReference.Value.StartsWith(cellColumnReference))
                        {
                            theCell = cell;
                            break;
                        }
                    }
                    if (theCell != null)
                    {
                        value = theCell.InnerText;
                        // If the cell represents an integer number, you are done. 
                        // For dates, this code returns the serialized value that represents the date. The code handles strings and 
                        // Booleans individually. For shared strings, the code looks up the corresponding value in the shared string table. For Booleans, the code converts the value into the words TRUE or FALSE.
                        if (theCell.DataType != null)
                        {
                            switch (theCell.DataType.Value)
                            {
                                case CellValues.SharedString:
                                    // For shared strings, look up the value in the shared strings table.
                                    var stringTable = wbPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                                    // If the shared string table is missing, something is wrong. Return the index that is in the cell. Otherwise, look up the correct text in the table.
                                    if (stringTable != null)
                                    {
                                        value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
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
                        }
                    }
                    return value;
                }
                private static string GetCellValue(WorkbookPart wbPart, List<Cell> theCells, int index)
                {
                    return GetCellValue(wbPart, theCells, GetExcelColumnName(index));
                }
                private static string GetExcelColumnName(int columnNumber)
                {
                    int dividend = columnNumber;
                    string columnName = String.Empty;
                    int modulo;
                    while (dividend > 0)
                    {
                        modulo = (dividend - 1) % 26;
                        columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                        dividend = (int)((dividend - modulo) / 26);
                    }
                    return columnName;
                }
        
                //Only xlsx files
                public static DataTable GetDataTableFromExcelFile(string filePath, string sheetName = "")
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        using (SpreadsheetDocument document = SpreadsheetDocument.Open(filePath, false))
                        {
                            WorkbookPart wbPart = document.WorkbookPart;
                            IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                            string sheetId = sheetName != "" ? sheets.Where(q => q.Name == sheetName).First().Id.Value : sheets.First().Id.Value;
                            WorksheetPart wsPart = (WorksheetPart)wbPart.GetPartById(sheetId);
                            SheetData sheetdata = wsPart.Worksheet.Elements<SheetData>().FirstOrDefault();
                            int totalHeaderCount = sheetdata.Descendants<Row>().ElementAt(0).Descendants<Cell>().Count();
                            //Get the header                    
                            for (int i = 1; i <= totalHeaderCount; i++)
                            {
                                dt.Columns.Add(GetCellValue(wbPart, sheetdata.Descendants<Row>().ElementAt(0).Elements<Cell>().ToList(), i));
                            }
                            foreach (Row r in sheetdata.Descendants<Row>())
                            {
                                if (r.RowIndex > 1)
                                {
                                    DataRow tempRow = dt.NewRow();
                                    
                                    //Always get from the header count, because the index of the row changes where empty cell is not counted
                                    for (int i = 1; i <= totalHeaderCount; i++)
                                    {
                                        tempRow[i - 1] = GetCellValue(wbPart, r.Elements<Cell>().ToList(), i);
                                    }
                                    dt.Rows.Add(tempRow);
                                }
                            }                    
                        }
                    }
                    catch (Exception ex)
                    {
        
                    }
                    return dt;
                }
            }

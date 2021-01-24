    public void MapExcelToDictionary()
            {
                var fileName = @"C:\XML\Vehicles.xlsx";
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
                {
                    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
    
                    var sheets = workbookPart.Workbook.Descendants<Sheet>();
                    Sheet sheet = sheets.FirstOrDefault();
    
                    var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                    var rows = worksheetPart.Worksheet.Descendants<Row>().ToList();
    
                    Row headerRow = rows.First();
                    var headerCells = headerRow.Elements<Cell>();
                    int totalColumns = headerCells.Count();
    
                    List<string> lstHeaders = new List<string>();
                    foreach (var value in headerCells)
                    {
                        var stringId = Convert.ToInt32(value.InnerText);
                        lstHeaders.Add(workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(stringId).InnerText);
                    }
    
                    // Remove the header row
                    rows.RemoveAt(0);
    
                    Dictionary<string, List<KeyValuePair<string, string>>> dict = new Dictionary<string, List<KeyValuePair<string, string>>>();
    
                    var productID = string.Empty;
    
                    foreach (Row r in rows)
                    {
                        List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();
    
                        foreach (Cell c in r.Elements<Cell>())
                        {
                            if (c.DataType != null && c.DataType == CellValues.SharedString)
                            {
                                var stringId = Convert.ToInt32(c.InnerText);
                                string val = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(stringId).InnerText;
    
                                switch (GetColumnIndex(c.CellReference))
                                {
                                    case 1:
                                        productID = val;
                                        break;
    
                                    case 2:
                                        keyValuePairs.Add(new KeyValuePair<string, string>("Model", val));
                                        break;
    
                                    case 3:
                                        keyValuePairs.Add(new KeyValuePair<string, string>("Type", val));
                                        break;
    
                                    case 4:
                                        keyValuePairs.Add(new KeyValuePair<string, string>("Color", val));
                                        break;
    
                                    case 5:
                                        keyValuePairs.Add(new KeyValuePair<string, string>("MaSpeed", val));
                                        break;
    
                                    case 6:
                                        keyValuePairs.Add(new KeyValuePair<string, string>("Manufacturer", val));
                                        break;
                                }
    
                            }
                            else if (c.InnerText != null || c.InnerText != string.Empty)
                            {
                                //Do code here
                            }
                        }
    
                        dict.Add(productID, keyValuePairs);
                    }
    
                    Console.ReadKey();
                }
            }
    
            private static int? GetColumnIndex(string cellReference)
            {
                if (string.IsNullOrEmpty(cellReference))
                {
                    return null;
                }
    
                string columnReference = Regex.Replace(cellReference.ToUpper(), @"[\d]", string.Empty);
    
                int columnNumber = -1;
                int mulitplier = 1;
    
                foreach (char c in columnReference.ToCharArray().Reverse())
                {
                    columnNumber += mulitplier * ((int)c - 64);
    
                    mulitplier = mulitplier * 26;
                }
    
                return columnNumber + 1;
            }

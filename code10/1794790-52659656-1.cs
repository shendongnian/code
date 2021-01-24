    public void MapExcelToDictionary()
            {
                var fileName = @"C:\XML\Vehicles.xlsx";
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
                {
                    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
    
                    //Get sheet from excel
                    var sheets = workbookPart.Workbook.Descendants<Sheet>();
    
                    //First sheet from excel
                    Sheet sheet = sheets.FirstOrDefault();
    
                    var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                    var rows = worksheetPart.Worksheet.Descendants<Row>().ToList();
    
                    //Get all data rows from sheet
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
    
                   //Dictionary to map row data into key value pair
                    Dictionary<string, List<KeyValuePair<string, string>>> dict = new Dictionary<string, List<KeyValuePair<string, string>>>();
    
                    var productID = string.Empty;
    
                    //Iterate to all rows
                    foreach (Row r in rows)
                    {
                        List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();
    
                        //Iterate to all cell in current row
                        foreach (Cell c in r.Elements<Cell>())
                        {
                            if (c.DataType != null && c.DataType == CellValues.SharedString)
                            {
                                var stringId = Convert.ToInt32(c.InnerText);
                                string val = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(stringId).InnerText;
    
                                //Find cell index and map each cell and add in key value pair
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
    
                        //Add productId and its repsective data to dictionary
                        dict.Add(productID, keyValuePairs);
                    }
    
                    Console.ReadKey();
                }
            }

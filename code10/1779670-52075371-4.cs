    public string GetIndexBySearch(string search)
            {
    
                WorkbookPart workbookPart = ImportExcel();
                var sheets = workbookPart.Workbook.Descendants<Sheet>();
                Sheet sheet = sheets.Where(x => x.Name.Value == "you sheet name in excel document").FirstOrDefault();
    
                string index = string.Empty;
    
                if (sheet != null)
                {
                    var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                    var rows = worksheetPart.Worksheet.Descendants<Row>().ToList();
    
                    // Remove the header row
                    rows.RemoveAt(0);
    
                    foreach (var row in rows)
                    {
                        var cellss = row.Elements<Cell>().ToList();
    
                        foreach (var cell in cellss)
                        {
                            var value = cell.InnerText;
                            var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                            value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
                            bool isFound = value.Trim().ToLower().Contains(search.Trim().ToLower());
    
                            if (isFound)
                            {
                                index = $"[{row.RowIndex}, {GetColumnIndex(cell.CellReference)}]";
                                return index;
                            }
    
                        }
                    }
                }
    
                return index;
            }

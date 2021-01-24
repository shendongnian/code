    public DataTable GetDataTableFromExcel(string path)
        {
            var dataTable = new DataTable();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(path, false))
            {
                //to read data from the 1st sheet
                Worksheet worksheet = SpreedsheetHelper.GetWorksheetPart(doc.WorkbookPart, "myFirstSheetname").Worksheet;
                SheetData sheetData = worksheet.GetFirstChild<SheetData>();
                IEnumerable<Row> rows = sheetData.Descendants<Row>();
                var cells = SpreedsheetHelper.GetRowCells(rows.ElementAt(0));
                //creating the columns
                foreach (Cell cell in cells)
                {
                    var colname = SpreedsheetHelper.TryGetCellValue(doc, cell);
                    colname = colname == null ? "" : colname;
                    dataTable.Columns.Add(colname, SpreedsheetHelper.GetCellDatatype(cell));
                }               
  
               //adding data to datatable         
                foreach (Row row in rows)
                {
                    DataRow dataRow = dataTable.NewRow();
                    var rowcells = SpreedsheetHelper.GetRowCells(row);
                    var cellindex = 0;
                    foreach (Cell cell in rowcells)
                    {
                        var value = SpreedsheetHelper.TryGetCellValue(doc, cell);
                        value = value == null ? "" : value;
                        dataRow[cellindex] = value;
                        cellindex++;
                    }                    
                    dataTable.Rows.Add(dataRow);
                }
            }
            //to handle the blank row added at the top of datatable
            dataTable.Rows.RemoveAt(0);
            return dataTable;
        }

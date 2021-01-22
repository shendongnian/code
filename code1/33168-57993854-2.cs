    var sheetData = new SheetData();
    var row = UpdateCell("A","Hello World", 5);
                    sheetData.Append(row);
     worksheet.Append(sheetData);
                    
    private static Row UpdateCell(string columnName,string value uint rowIndex)
    {
           Row row = new Row { RowIndex = (uint)rowIndex };
           Cell  c1 = new TextCell(columnName, value, rowIndex);
           row.Append(c1);
           return row;            
    }

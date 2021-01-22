    var sheetData = new SheetData();
    var row = UpdateCell("A","Hello World", 5);
    sheetData.Append(row);
    worksheet.Append(sheetData);
                    
    private static Row UpdateCell(string columnName, string value, int rowIndex)
    {
           Row row = new Row { RowIndex = (uint)rowIndex };
           Cell  c1 = new TextCell(columnName, value, rowIndex);
           row.Append(c1);
           return row;            
    }
    public class TextCell : Cell
    {
        public TextCell(string header, string text, int index)
        {
            this.DataType = CellValues.InlineString;
            this.CellReference = header + index;
            //Add text to the text cell.
            this.InlineString = new InlineString { Text = new Text { Text = text } };
        }
    }

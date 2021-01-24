    public object[,] ReadMultiCellValues(int row, int column, int numRows, int numColumns)
    {
        // Check for invalid arguments.
        ValidateCell(row, column);
        // Create an Excel Range object emcompassing the workbook's starting cell.
        Range range = (Range)_worksheet.Cells[row, column];
        // Resize the range to the desired dimensions.
        range = range.get_Resize(numRows, numColumns);
        // Read the cells' values from the spreadsheet.
        return (object[,])range.Value2;
    }

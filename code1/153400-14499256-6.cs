    DateTime valueDate = DateTime.Now;
    string valueString = valueDate.ToOADate().ToString();
    CellValue cellValue = new CellValue(valueString);
    
    Cell cell = new Cell();
    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
    cell.StyleIndex = yourStyle; //StyleIndex of CellFormat cfBaseDate -> See below
    cell.Append(cellValue);
